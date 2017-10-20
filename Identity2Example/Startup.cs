using Identity2Example.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Web.Configuration;

[assembly: OwinStartupAttribute(typeof(Identity2Example.Startup))]
namespace Identity2Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }
        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // creating Creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = WebConfigurationManager.AppSettings["adminLogin"];
                user.Email = WebConfigurationManager.AppSettings["adminMail"];

                string userPass = WebConfigurationManager.AppSettings["adminPass"];

                var chkUser = UserManager.Create(user, userPass);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                    UserManager.AddToRole(user.Id, "User");

                }
            }


        }
    }
}

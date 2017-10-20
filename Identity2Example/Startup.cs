using Identity2Example.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;
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
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userLogin = WebConfigurationManager.AppSettings["adminLogin"];
            var userEmail = WebConfigurationManager.AppSettings["adminMail"];
            var userPass = WebConfigurationManager.AppSettings["adminPass"];
            ApplicationUser user = null;

            // creating Creating the User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
                

            }

            // In Startup app is creating the Admin Role   
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            // Валидация данных
            if (userLogin.Length >= 6 && userEmail.Length >= 6 && userPass.Length >= 6)
            { 
                // Если пользователя не нашли, создаем нового
                if (userManager.FindByName(userLogin) == null && userManager.FindByEmail(userEmail) == null)
                {
                    user = new ApplicationUser { UserName = userLogin, Email = userEmail, EmailConfirmed = true };
                    var result = userManager.Create(user, userPass);
                    //Add default User to Role Admin
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Admin");
                        // userManager.AddToRole(user.Id, "User");
                    }
                }
                // Иначе изменяем данные старого
                else
                {
                    user = (from us in context.Users
                                .Where(u => u.UserName == userLogin || u.Email == userEmail)
                            select us).FirstOrDefault();

                    if(user != null)
                    {
                        user.UserName = userLogin;
                        user.Email = userEmail;
                        userManager.RemovePassword(user.Id);
                        userManager.AddPassword(user.Id, userPass);
                    }
                }
            }


        }
    }
}

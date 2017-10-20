using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace Identity2Example.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }

        // Your Extended Properties
        [Display(Name = "Имя")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string LastName { get; set; }

        //// Дата рождения
        //[Display(Name = "Дата рождения")]
        //[Range(1900, 2100, ErrorMessage = "Недопустимый год")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime DOB { get; set; }

        // Пол
        [Display(Name = "Пол")]      
        public UserGender Gender { get; set; }

        [Display(Name = "О себе")]
        [MaxLength(100, ErrorMessage = "Превышена максимальная длина записи")]
        public string About { get; set; }
    }

    public enum UserGender : byte
    {
        Указать = 0,
        Мужской = 1,
        Женский = 2
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Удалить 
        // public System.Data.Entity.DbSet<Identity2Example.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
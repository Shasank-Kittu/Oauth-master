using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Oauth.Models
{
    public class Class1
    {
    }
    public class ExtendedUser : IdentityUser
    {
        public new string UserName { get; set; }

        public Task<ClaimsIdentity> GenerateUserIdentity(UserManager<ExtendedUser> userManager, string authenticationType)
        {
            var userIdentity =  userManager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ExtendedUserDbContext : IdentityDbContext<ExtendedUser>
    {
        public ExtendedUserDbContext() : base("name=DefaultConnection")
        {

        }
        public static ExtendedUserDbContext Create()
        {
            return new ExtendedUserDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<ExtendedUser>();
            user.Property(x => x.UserName).IsRequired();
        }
    }
}
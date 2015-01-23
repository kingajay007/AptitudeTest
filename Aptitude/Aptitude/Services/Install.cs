using Aptitude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Aptitude.Services
{
    public class Install
    {
        public bool CreateAdmin(ApplicationDbContext context, string email, String password)
        {
            
            try
            {
                using (context = new ApplicationDbContext())
                {
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    if (!context.Roles.Any(x => x.Name == "Admin") && context.Users.Any(x => x.Email == email))
                    {
                        var user = new ApplicationUser { UserName = email, Email = email, };
                        userManager.Create(user, password);
                        //new CheckingAccountService(context).CreateCheckingAccount("Admin","User",user.Id,1000);

                        context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Admin" });
                        context.SaveChanges();

                        userManager.AddToRole(user.Id, "Admin");
                    }

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
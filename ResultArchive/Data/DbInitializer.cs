using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResultArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Data
{
    public static class DbInitializer
    {
       

        public static void SeedData(DBContext db, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            RunMigration(db);
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void RunMigration(DBContext db)
        {
            if(db.Database.GetPendingMigrations().Count() > 0)
            {
                db.Database.Migrate();
            }

        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("agavitalisogbonna@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "agavitalisogbonna@gmail.com";
                user.Email = "agavitalisogbonna@gmail.com";
                user.FirstName = "Nancy";
                user.LastName = "Davolio";

                IdentityResult result = userManager.CreateAsync(user, "08032647672").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }

            if (userManager.FindByNameAsync("vivvaa.vivvaa@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "vivvaa.vivvaa@gmail.com";
                user.Email = "vivvaa.vivvaa@gmail.com";
                user.FirstName = "Nancy";
                user.LastName = "Davolio";

                IdentityResult result = userManager.CreateAsync(user, "08032647672").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}

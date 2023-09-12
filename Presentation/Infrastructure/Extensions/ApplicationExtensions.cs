using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Presentation.Infrastructure.Extensions
{
    public static class ApplicationExtensions
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            string userName = "admin";
            string password = "admin123";
            
            UserManager<AppUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            RoleManager<AppRole> roleManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<AppRole>>();

            AppUser user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new AppUser
                {
                    Id = 1,
                    Name = "Talha",
                    Surname = "Türk",
                    UserName = userName,
                    Email = "info@admin.com",
                    PhoneNumber = "5557593546",
                    ImageUrl = "/images/user/talhaturk.jpg"
                };

                var result = await userManager.CreateAsync(user, password);
                if(!result.Succeeded)
                {
                    throw new Exception("Admin user could not created.");
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                );

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for admin.");
                }
            }
        }

        public static async void ConfigureDefaultEditorUser(this IApplicationBuilder app)
        {
            string userName = "editor";
            string password = "editor123";

            UserManager<AppUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            AppUser user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new AppUser
                {
                    Id = 2,
                    Name = "John",
                    Surname = "Silver",
                    UserName = userName,
                    Email = "info@editor.com",
                    PhoneNumber = "5557593545",
                    ImageUrl = "/images/user/johnsilver.jpg"
                };

                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    throw new Exception("Editor user could not created.");
                }

                var roleResult = await userManager.AddToRoleAsync(user, "Editor");

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for editor.");
                }
            }
        }

        public static async void ConfigureDefaultUser(this IApplicationBuilder app)
        {
            string userName = "user";
            string password = "user123";

            UserManager<AppUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            AppUser user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new AppUser
                {
                    Id = 3,
                    Name = "Alan",
                    Surname = "Turing",
                    UserName = userName,
                    Email = "info@user.com",
                    PhoneNumber = "5557593544",
                    ImageUrl = "/images/user/alanturing.jpg"
                };

                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    throw new Exception("User could not created.");
                }

                var roleResult = await userManager.AddToRoleAsync(user, "User");

                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for user.");
                }
            }
        }
    }
}

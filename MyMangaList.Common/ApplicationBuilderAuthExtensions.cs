using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyMangaList.Models;

namespace MyMangaList.Common
{
    public static class ApplicationBuilderAuthExtensions
    {
        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(Constants.Administrator),
            new IdentityRole(Constants.User)
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        var result = await roleManager.CreateAsync(role);
                    }
                }

                var user = await userManager.FindByNameAsync(Constants.AdminUsername);
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = Constants.AdminUsername,
                        Email = Constants.AdminEmail,
                    };

                    var result =await userManager.CreateAsync(user, Constants.AdminPassword);
                    result = await userManager.AddToRoleAsync(user, roles[0].Name);
                }
            }
        }
    }
}

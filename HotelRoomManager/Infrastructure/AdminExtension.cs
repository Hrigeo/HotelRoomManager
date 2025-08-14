using HotelRoomManager.Data.Models.User;
using Microsoft.AspNetCore.Identity;

namespace HotelRoomManager.Infrastructure
{
    public static class AdminExtension
    {

        private const string AdminRole = "Admin";

        public static async Task CreateAdminAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sp = scope.ServiceProvider;
            var logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger("AdminBootstrap");
            var roles = sp.GetRequiredService<RoleManager<IdentityRole>>();
            var users = sp.GetRequiredService<UserManager<ApplicationUser>>();
            var config = sp.GetRequiredService<IConfiguration>();

            if (!await roles.RoleExistsAsync(AdminRole))
            {
                var createRole = await roles.CreateAsync(new IdentityRole(AdminRole));
                if (!createRole.Succeeded)
                {
                    logger.LogError("Failed to create role {Role}: {Errors}",
                        AdminRole, string.Join("; ", createRole.Errors));
                    return;
                }
            }



            // 2) Add existing user (from appsettings) to the role
            var email = config["Seed:Admin:Email"];   // e.g., "g.achkov@yahoo.com"
            if (string.IsNullOrWhiteSpace(email))
            {
                logger.LogWarning("Seed:Admin:Email not configured. Skipping admin bootstrap.");
                return;
            }

            var user = await users.FindByEmailAsync(email);
            if (user == null)
            {
                logger.LogWarning("User {Email} not found. Skipping admin bootstrap.", email);
                return;
            }

            if (!await users.IsInRoleAsync(user, AdminRole))
            {
                var add = await users.AddToRoleAsync(user, AdminRole);
                if (!add.Succeeded)
                    logger.LogError("Failed adding {Email} to {Role}: {Errors}",
                        email, AdminRole, string.Join("; ", add.Errors));
                else
                    logger.LogInformation("Added {Email} to {Role}.", email, AdminRole);
            }
            else
            {
                logger.LogInformation("User {Email} already in {Role}.", email, AdminRole);
            }

        }
    }
}

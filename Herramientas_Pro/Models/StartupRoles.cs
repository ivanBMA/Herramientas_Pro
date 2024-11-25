using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Herramientas_Pro.Data
{
    public class StartupRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "User", "Manager", "Guest" }; // Define los roles que necesitas

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}

using BaseArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseArchitecture.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultUser = new User()
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@project.com",
                    NormalizedEmail = "ADMIN@PROJECT.COM",
                    Name = "admin",
                    NameLocalization = "مدير",
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                    PhoneNumber = "123456",
                    Address = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                await _userManager.CreateAsync(defaultUser, "Admin.123");
                await _userManager.AddToRoleAsync(defaultUser, "Admin");
            }
        }
    }
}

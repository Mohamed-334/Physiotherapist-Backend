using BaseArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseArchitecture.Infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            var rolesCount = await _roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Patient",
                    NormalizedName = "PATIENT",
                    NameLocalization = "مريض",
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Doctor",
                    NormalizedName = "DOCTOR",
                    NameLocalization = "دكتور",
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Intern",
                    NormalizedName = "INTERN",
                    NameLocalization = "طالب امتياز",
                    CreationDate = DateTime.Now,
                    CreatorName = "System",
                });
            }
        }
    }
}

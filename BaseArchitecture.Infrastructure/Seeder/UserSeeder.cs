using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhysiotherapistProject.Domain.Entities;

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
    public static class DbSeeder
    {
        public static async Task SeedClinicsAsync(AppDbContext _context)
        {
            var usersCount = await _context.Clinics.CountAsync();
            if (usersCount <= 0)
            {
                var defaultUser = new List<Clinic>
                {
                    new Clinic()
                    {
                        Name = "Orthopedics",
                        NameLocalization = "العظام",
                        StartHour =9 ,
                        EndHour =1 ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },
                    new Clinic()
                    {
                        Name = "Neurology",
                        NameLocalization = "الأعصاب",
                        StartHour =9 ,
                        EndHour =1 ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },
                    new Clinic()
                    {
                        Name = "Pediatrics",
                        NameLocalization = "الأطفال",
                        StartHour = 9,
                        EndHour = 1,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },
                    new Clinic()
                    {
                        Name = "Women’s Health",
                        NameLocalization = "صحة المرأة",
                        StartHour = 9,
                        EndHour = 1,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },
                    new Clinic()
                    {
                        Name = "Intensive Care",
                        NameLocalization = "العناية المركزة",
                        StartHour = 9,
                        EndHour = 1,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },
                    new Clinic()
                    {
                        Name = "Internal Medicine, Pulmonology & Cardiology",
                        NameLocalization = "الباطنة والصدر والقلب",
                        StartHour = 9,
                        EndHour = 1,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },
                    new Clinic()
                    {
                        Name = "Surgery, Dermatology & Burns",
                        NameLocalization = "الجراحة والجلد والحروق",
                        StartHour = 9,
                        EndHour = 1,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                    },

                };
                await _context.SaveChangesAsync();
            }
        }
    }
}

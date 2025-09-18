using BaseArchitecture.Infrastructure.Context;
using PhysiotherapistProject.Domain.Entities;

namespace BaseArchitecture.Infrastructure.Seeder
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext _context)
        {
            if (!_context.Clinics.Any())
            {
                var defaultClinics = new List<Clinic>
                {
                    new Clinic()
                    {
                        Name = "Orthopedics",
                        NameLocalization = "العظام",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/عظام.jpeg"
                    },
                    new Clinic()
                    {
                        Name = "Neurology",
                        NameLocalization = "الأعصاب",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/أعصاب.jpeg"
                    },
                    new Clinic()
                    {
                        Name = "Pediatrics",
                        NameLocalization = "الأطفال",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/أطفال.jpeg"
                    },
                    new Clinic()
                    {
                        Name = "Women’s Health",
                        NameLocalization = "صحة المرأة",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/صحة-المرأة.jpeg"
                    },
                    new Clinic()
                    {
                        Name = "Intensive Care",
                        NameLocalization = "العناية المركزة",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/عناية.jpeg"
                    },
                    new Clinic()
                    {
                        Name = "Internal Medicine, Pulmonology & Cardiology",
                        NameLocalization = "الباطنة والصدر والقلب",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/باطنةوصدروقلب.jpeg"
                    },
                    new Clinic()
                    {
                        Name = "Surgery, Dermatology & Burns",
                        NameLocalization = "الجراحة والجلد والحروق",
                        StartHour =new TimeSpan(9,00,00) ,
                        EndHour =new TimeSpan(01,00,00) ,
                        CreationDate = DateTime.Now,
                        CreatorName = "System",
                        IsDeleted = false,
                        ClinicImage = "/Images/Clinics/جراحةوجلدوحروق.jpeg"
                    },

                };
                await _context.Clinics.AddRangeAsync(defaultClinics);
                await _context.SaveChangesAsync();
            }
        }
    }
}

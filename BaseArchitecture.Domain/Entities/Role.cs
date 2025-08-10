using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace BaseArchitecture.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public string? NameLocalization { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? CreatorName { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public string? ModifierName { get; set; }
        public DateTime? ModificationDate { get; set; } = DateTime.Now;

        public string? GetLocalizedName()
        {
            if (string.IsNullOrEmpty(NameLocalization))
                return Name;
            CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
            if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return NameLocalization;
            return Name;
        }
    }
}

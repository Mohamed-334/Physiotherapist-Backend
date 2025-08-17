using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BaseArchitecture.Domain.Enums
{
    public static class EnumExtensions
    {
        #region Enum
        public enum SessionStatusEnum
        {
            [Display(Name = "معلق")]
            Pending = 1,
            [Display(Name = "تم الالغاء")]
            Cancelled = 2,
            [Display(Name = "تم الحضور")]
            Attended = 3,

        }
        #endregion

        #region Methods
        public static string? GetDisplayName(this Enum enumValue)
        {
            var member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            var displayAttribute = member?.GetCustomAttribute<DisplayAttribute>();

            var rawDisplay = displayAttribute?.GetName() ?? enumValue.ToString();

            return rawDisplay;
        }
        #endregion
    }
}

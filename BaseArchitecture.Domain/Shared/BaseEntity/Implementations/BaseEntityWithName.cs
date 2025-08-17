﻿using BaseArchitecture.Domain.Shared.BaseEntity.Interfaces;
using System.Globalization;
namespace BaseArchitecture.Domain.Shared.BaseEntity.Implementations
{
    public class BaseEntityWithName : BaseEntity, IBaseEntityWithName
    {
        public string? Name { get; set; }
        public string? NameLocalization { get; set; }


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

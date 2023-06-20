using System;
using System.ComponentModel;

namespace obilet_core.Helpers.Validation
{
    public enum Errors
    {
        [Description("Seçenekler aynı olamaz")]
        SameOptions,
        [Description("Tarih bugünden önce olamaz")]
        DateBeforeToday
    }

    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}

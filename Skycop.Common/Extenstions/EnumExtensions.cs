using System;
using System.ComponentModel;
using System.Reflection;

namespace Skycop.Common.Extenstions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum value)
        {
            var description = value.ToString();
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        public static int ToValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}

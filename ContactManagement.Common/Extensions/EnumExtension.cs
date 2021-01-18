using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContactManagement.Common.Extensions
{
    /// <summary>
    /// This class extends enum to add the functionality of get the description
    /// </summary>
    public static class EnumExtension
    {
        public static string GetDescription(this Enum source)
        {
            var description = string.Empty;
            var attributes = default(Attribute);
            var mi = source.GetType().GetMember(source.ToString()).FirstOrDefault();

            attributes = (DescriptionAttribute)mi.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (attributes != null)
            {
                description = (attributes as DescriptionAttribute).Description;
            }
            else
            {
                attributes = (DisplayAttribute)mi.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

                if (attributes != null)
                {
                    description = (attributes as DisplayAttribute).Description;
                }
            }

            return string.IsNullOrEmpty(description) ? source.ToString() : description;
        }

    }
}

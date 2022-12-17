using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Extensions
{
    public static class EnumExtension
    {
        public static string? GetDescription<T>(this T value) where T : IConvertible
        {
            string? description = null;
            try
            {
                if (value is Enum)
                {
                    Type type = value.GetType();
                    Array arr = Enum.GetValues(type);

                    foreach (int val in arr)
                    {
                        if (val == value.ToInt32(CultureInfo.InvariantCulture))
                        {
                            var memInfo = type.GetMember(type.GetEnumName(val));
                            var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                            if (descriptionAttributes.Length > 0)
                            {
                                description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                description = "N/A";
            }

            return description;
        }
    }
}

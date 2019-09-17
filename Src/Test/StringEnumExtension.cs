using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Test
{
    public static class StringEnumExtension
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string desc = string.Empty;

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        MemberInfo[] memInfo = type.GetMember(type.GetEnumName(val));
                        object[] descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (descriptionAttributes.Length > 0)
                        {
                            desc = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        }
                        break;
                    }
                }
            }
            return desc;
        }
    }
}
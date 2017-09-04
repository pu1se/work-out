using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace YourWorkOut
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            if (value == null)
                return "";

            var description = value.GetType().GetTypeInfo().GetCustomAttribute<DescriptionAttribute>();

            if (description != null)
            {
                return description.Value;
            }
            return value.ToString();
        }

        public static List<T> EnumerateEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static Dictionary<T, string> EnumerateEnumWithDescription<T>()
        {
            return EnumerateEnum<T>().ToDictionary(x => x, x => GetDescription(x as Enum));
        }

        public static T Parse<T>(string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value.Trim(), true);
            }
            catch (Exception)
            {
                // ignored
            }

            return EnumerateEnumWithDescription<T>().First(x => x.Value == value).Key;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace YourWorkOut
{
    public static class ObjectExtensions
    {
        public static bool IsNullOrEmpty(this string st)
        {
            return string.IsNullOrEmpty(st);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }

        public static string Join(this IEnumerable<string> list, string delimiter)
        {
            if (list == null)
                return "";

            return list.DefaultIfEmpty("").Aggregate((a,b)=>a+delimiter+b);
        }

        public static bool IsNull(this int? obj)
        {
            return !obj.HasValue;
        }

        
    }
}
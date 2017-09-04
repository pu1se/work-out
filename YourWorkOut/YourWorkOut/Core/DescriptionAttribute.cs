using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWorkOut
{
    public class DescriptionAttribute : Attribute
    {
        public string Value { get; }

        public DescriptionAttribute(string description)
        {
            Value = description;
        }
    }
}

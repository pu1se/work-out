using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YourWorkOut.DataStore.Enums
{
    public enum DurationEnum
    {
        [Description("10 sec")]
        s10 = 10,

        [Description("20 sec")]
        s20 = 20,

        [Description("30 sec")]
        s30 = 30,

        [Description("40 sec")]
        s40 = 40,

        [Description("50 sec")]
        s50 = 50,

        [Description("60 sec")]
        s60 = 60,

        [Description("80 sec")]
        s80 = 80,

        [Description("100 sec")]
        s100 = 100,
    }
}

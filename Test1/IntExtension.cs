using System;
using System.Collections.Generic;
using System.Text;

namespace IntExtensions
{
    public static class IntExtension
    {
        public static bool isDividableBy3(this int i)
        {
            return i % 3 == 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Parliament.Common.Helper
{
    public class EnumHelper
    {
        public static List<T> GetValues<T>()
        {
            return Enum.GetValues(typeof (T)).Cast<T>().ToList();
        }
    }
}
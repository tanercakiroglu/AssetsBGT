using System;
using System.Linq;

namespace AssetsBGT.Service.Util
{
    public class Utility
    {
        public static bool IsAnyPropNullOrEmpty(object obj)
        {
            bool isAnyPropEmpty = obj.GetType().GetProperties()
                                .Where(p => p.GetValue(obj) is string)
                                .Any(p => string.IsNullOrWhiteSpace((p.GetValue(obj) as string)));
            if (isAnyPropEmpty)
                throw new ArgumentNullException();

            return isAnyPropEmpty;
        }

        public static bool IsNullOrEmpty(string str)
        {
            bool isNullOrEmpty = str == null || str.Trim().Length <= 0 ? true : false;
            if (isNullOrEmpty)
                throw new ArgumentNullException();

            return isNullOrEmpty;
        }
    }
}
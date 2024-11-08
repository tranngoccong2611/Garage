using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Common.Extension
{
    public static class ValidationExtensions
    {
        // đặt lịch thì phải lớn hơn ngày hiện tại
        public static bool IsInFutureDate(this DateTime date)
        {
            return date > DateTime.Now;
        }

        public static bool IsPhoneNumber(this string number)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(number, @"^\+?[1-9]\d{1,14}$");
        }

        public static bool HasMinimumLength(this string str, int minLength)
        {
            if (str == null)
                return false;
            return str.Length >= minLength;
        }
    }
}

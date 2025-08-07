using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarStoreApi.Domain.Validator
{
    public class PhoneValidator
    {
        public static bool IsValid(string phone)
        {
            return !string.IsNullOrEmpty(phone) &&
                   Regex.IsMatch(phone, @"^01[0125]\d{8}$");
        }
    }
}

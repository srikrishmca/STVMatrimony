using System;
using System.Collections.Generic;
using System.Text;

namespace STVMatrimony.Helpers.Validations
{
   public class IsEmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            if (str.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(str);
                return addr.Address == str;
            }
            catch
            {
                return false;
            }
        }
    }

    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value.ToString();

            return !string.IsNullOrWhiteSpace(str);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace STVMatrimony.Helpers.Validations
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }

        bool Check(T value);
    }
    public interface IValidaty
    {
        bool IsValid { get; set; }
        bool IsButtonActive { get; set; }
    }
}

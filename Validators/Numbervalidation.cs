using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp_DataBinding_Ver2.Validators
{
    class Numbervalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            foreach (char c in input)
            {
                if(input.Length>11)
                {
                    return new ValidationResult(false, "Номер не может быть больше 11 цифр");
                }
                if (!char.IsDigit(c))
                {
                    return new ValidationResult(false, "В поле могут быть только цифры");

                }
            }

            return ValidationResult.ValidResult;
        }
    }
}

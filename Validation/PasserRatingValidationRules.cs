using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QBRatingSystem.Validation
{
    public class PasserRatingValidationRules : ValidationRule
    {
        public int Min { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int result = 0;

           if (int.TryParse(value as string,  out result))
            {
                return new ValidationResult(result>=Min, "Value must be greate than the minimum set");
            }
            else
            {
                return new ValidationResult(false, "Illegal characters entered");
            }
        }
    }
}

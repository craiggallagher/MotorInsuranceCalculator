using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MotorInsuranceCalculator
{
    class OccupationValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is ComboBoxItem)
                return new ValidationResult(false, "Selection is invalid.");
            return new ValidationResult(true, null);
        }
    }
}

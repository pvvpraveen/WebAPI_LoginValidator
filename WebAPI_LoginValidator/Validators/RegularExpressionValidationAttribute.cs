using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAPI_LoginValidator.Validators
{
    public class RegularExpressionValidationAttribute : ValidationAttribute
    {
        private readonly string pattern;

        public RegularExpressionValidationAttribute(string pattern)
        {
            this.pattern = pattern;
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), pattern);
        }
    }
}
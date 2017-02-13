using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebAPI_LoginValidator.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UserNameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var requiredAttribute=new RequiredAttribute();
            var emailAddressAttribute = new EmailAddressAttribute();
            var statedUserName = requiredAttribute.IsValid(value);
            var validUserName = emailAddressAttribute.IsValid(value);

            if (!statedUserName)
            {
                ErrorMessage = ErrorMessageProvider.GetStatusMessage(ValidationRules.UserNameEmptyRule);
                return false;
            }
            if (validUserName) return true;
            ErrorMessage = ErrorMessageProvider.GetStatusMessage(ValidationRules.UserNameInvalidRule);
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}
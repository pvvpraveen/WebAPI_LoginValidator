using System.Collections.Generic;

namespace WebAPI_LoginValidator
{
    public static class ErrorMessageProvider
    {
        private static readonly Dictionary<string,string> RuleMapper=new Dictionary<string, string>();

        static ErrorMessageProvider()
        {
            RuleMapper.Add(ValidationRules.UserNameEmptyRule,ErrorMessages.EmptyUserName);
            RuleMapper.Add(ValidationRules.UserNameInvalidRule, ErrorMessages.InvalidUserName);
            RuleMapper.Add(ValidationRules.PassWordLowerCaseRule, ErrorMessages.PasswordHasNoLowerCase);
            RuleMapper.Add(ValidationRules.PassWordUpperCaseRule, ErrorMessages.PasswordHasNoUpperCase);
            RuleMapper.Add(ValidationRules.PassWordSpecialCharacterRule, ErrorMessages.PasswordHasNoSpecialCharacters);
            RuleMapper.Add(ValidationRules.PassWordNumberRule, ErrorMessages.PasswordHasNoNumbers);
            RuleMapper.Add(ValidationRules.PassWordMinimumLengthRule, ErrorMessages.PasswordLengthNotSufficient);
        }

        public static string GetStatusMessage(string validationRule)
        {
            string status;
            RuleMapper.TryGetValue(validationRule, out status);
            return status;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace WebAPI_LoginValidator.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var validationRules = GetValidationRules();
            foreach (var validationRule in validationRules)
            {
                var validationAttribute = GetAttributeFromRule(validationRule);
                if (validationAttribute == null) continue;
                if (validationAttribute.IsValid(value.ToString())) continue;
                ErrorMessage = ErrorMessageProvider.GetStatusMessage(validationRule.RuleName);
                return false;
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }

        private static IEnumerable<ValidationRule> GetValidationRules()
        {
            try
            {
                var passwordRulesSection = ConfigurationManager.GetSection("PasswordRules") as Hashtable;
                return passwordRulesSection?.Cast<DictionaryEntry>()
                    .Select(rule => new ValidationRule
                    {
                        RuleName = rule.Key.ToString(),
                        RuleValue = rule.Value.ToString(),
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(ex.Message);
            }
        }

        private static ValidationAttribute GetAttributeFromRule(ValidationRule validationRule)
        {
            switch (validationRule.RuleName)
            {
                case ValidationRules.PassWordLowerCaseRule:
                    return IsRuleEnabled(validationRule.RuleValue)
                        ? new RegularExpressionValidationAttribute(RegexConstants.LowerCase)
                        : null;
                case ValidationRules.PassWordUpperCaseRule:
                    return IsRuleEnabled(validationRule.RuleValue)
                        ? new RegularExpressionValidationAttribute(RegexConstants.UpperCase)
                        : null;
                case ValidationRules.PassWordSpecialCharacterRule:
                    return IsRuleEnabled(validationRule.RuleValue)
                        ? new RegularExpressionValidationAttribute(RegexConstants.SpecialCharacter)
                        : null;
                case ValidationRules.PassWordNumberRule:
                    return IsRuleEnabled(validationRule.RuleValue)
                        ? new RegularExpressionValidationAttribute(RegexConstants.Number)
                        : null;
                case ValidationRules.PassWordMinimumLengthRule:
                    return new MinLengthAttribute(Convert.ToInt32(validationRule.RuleValue));
                default:
                    throw new Exception("Rule is not implemented");
            }
        }

        private static bool IsRuleEnabled(string value)
        {
            return value.Equals("Enable", StringComparison.InvariantCulture);
        }
    }
}


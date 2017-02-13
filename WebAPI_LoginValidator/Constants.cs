namespace WebAPI_LoginValidator
{
    public static class ErrorMessages
    {
        public const string EmptyUserName = "The username must be stated. It must not be empty or null.";
        public const string InvalidUserName = "The username must be a valid e-mail address.";
        public const string PasswordHasNoLowerCase = "The password must contain lowercase letters.";
        public const string PasswordHasNoUpperCase = "The password must contain uppercase letters.";
        public const string PasswordHasNoSpecialCharacters= "The password must contain special characters (not A-Z or 0-9).";
        public const string PasswordHasNoNumbers= "The password must contain numbers.";
        public const string PasswordLengthNotSufficient= "The password must be longer than configured length.";
    }

    public static class ValidationRules
    {
        public const string UserNameEmptyRule = "UserNameEmptyRule";
        public const string UserNameInvalidRule = "UserNameInvalidRule";
        public const string PassWordLowerCaseRule = "PassWordLowerCaseRule";
        public const string PassWordUpperCaseRule = "PassWordUpperCaseRule";
        public const string PassWordSpecialCharacterRule = "PassWordSpecialCharacterRule";
        public const string PassWordNumberRule = "PassWordNumberRule";
        public const string PassWordMinimumLengthRule = "PassWordMinimumLengthRule";
    }

    public static class RegexConstants
    {
        public const string LowerCase = @"(?=.*[a-z])";
        public const string UpperCase = @"(?=.*[A-Z])";
        public const string SpecialCharacter = @"(?=.*[\W])";
        public const string Number = @"(?=.*\d)";
    }
}
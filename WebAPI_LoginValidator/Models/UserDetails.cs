using WebAPI_LoginValidator.Validators;

namespace WebAPI_LoginValidator.Models
{
    public class UserDetails
    {
        [UserNameValidation]
        public string UserName { get; set; }

        [PasswordValidation]
        public string Password { get; set; }

    

    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class PasswordCriteriaValidation
    {
        public static bool IsValidPassword(string password, out string validationErrorMessage)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                validationErrorMessage = "Password cannot be empty. Try again.";
                return false;
            }
            else if (password.Length < 6)
            {
                validationErrorMessage = "Should be at least 6 chars. Try again.";
                return false;
            }
            validationErrorMessage = "";
            return true;
        }
    }
}

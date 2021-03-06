﻿using System.Collections.Generic;

namespace PasswordManager
{
    public class PasswordCriteriaValidation
    {
        delegate bool IsValid(string password);

        /// <summary>
        /// Make validation driven by this collection of rules
        /// </summary>
        static Dictionary<IsValid, string> invalidRulesAndMessages = new Dictionary<IsValid, string>
        {
            {(pwd)=>string.IsNullOrWhiteSpace(pwd),"Password cannot be empty. Try again." },
            {(pwd)=>pwd.Length < 6,"Should be at least 6 chars. Try again." },
            {(pwd)=>(pwd.ToLower() == pwd) || (pwd.ToUpper() == pwd),"Should contain upper and lower case. Try again." },
            {(pwd)=>(pwd.ToLower() == "qwerty") || (pwd.ToLower() == "password"),"Should not be a common password. Try again." },
        };

        public static bool IsValidPassword(string password, out string validationErrorMessage)
        {
            foreach (var invalidRule in invalidRulesAndMessages.Keys)
            {
                if (invalidRule(password))
                {
                    validationErrorMessage = invalidRulesAndMessages[invalidRule];
                    return false;
                }
            }

            validationErrorMessage = "";
            return true;
        }
    }
}

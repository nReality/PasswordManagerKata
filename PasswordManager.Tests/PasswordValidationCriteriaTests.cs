using System;
using NUnit.Framework;

namespace PasswordManager.Tests
{
    [TestFixture]
    public class PasswordValidationCriteriaTests
    {
        [TestCase("Longenough", TestName = "LongerThan6")]
        [TestCase("Sixchr", TestName = "Exactly6")]
        [TestCase("Veryloooooooooooooooooooooooooooooong", TestName = "VeryLong")]
        [TestCase("UPPERandlowercase", TestName = "UpperAndLowerCase")]

        public void ValidPasswordCriteria(string password)
        {
            string validationErrorMessage;
            Assert.True(PasswordCriteriaValidation.IsValidPassword(password, out validationErrorMessage));
        }

        [TestCase("", "Password cannot be empty. Try again.", TestName = "Empty")]
        [TestCase("five5", "Should be at least 6 chars. Try again.", TestName = "LessThan5")]
        [TestCase("alllowercase", "Should contain upper and lower case. Try again.", TestName = "LowerCaseOnly")]
        [TestCase("ALLUPPERCASE", "Should contain upper and lower case. Try again.", TestName = "UpperCaseOnly")]
        public void InValidPasswordCriteria(string password, string expectedErrorMessage)
        {
            string validationErrorMessage;
            Assert.False(PasswordCriteriaValidation.IsValidPassword(password, out validationErrorMessage));
            Assert.AreEqual(expectedErrorMessage, validationErrorMessage);
        }
    }
}

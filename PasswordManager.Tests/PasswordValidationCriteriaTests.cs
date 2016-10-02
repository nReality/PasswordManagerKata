using System;
using NUnit.Framework;

namespace PasswordManager.Tests
{
    [TestFixture]
    public class PasswordValidationCriteriaTests
    {
        [TestCase("longenough", TestName = "LongerThan6")]
        [TestCase("sixchr", TestName = "Exactly6")]
        [TestCase("veryloooooooooooooooooooooooooooooong", TestName = "VeryLong")]
        public void ValidPasswordCriteria(string password)
        {
            string validationErrorMessage;
            Assert.True(Program.IsValidPasswordCriteria(password, out validationErrorMessage));
        }

        [TestCase("", "Password cannot be empty. Try again.", TestName = "Empty")]
        [TestCase("five5", "Should be at least 6 chars. Try again.", TestName = "LessThan5")]
        public void InValidPasswordCriteria(string password, string expectedErrorMessage)
        {
            string validationErrorMessage;
            Assert.False(Program.IsValidPasswordCriteria(password, out validationErrorMessage));
            Assert.AreEqual(expectedErrorMessage, validationErrorMessage);
        }
    }
}

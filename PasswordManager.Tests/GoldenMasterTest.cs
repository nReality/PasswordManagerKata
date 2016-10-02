using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PasswordManager.Tests
{
    [TestClass]
    public class GoldenMasterTest
    {
        [TestMethod]
        public void GoldenMaster_TestWithoutChangingAnyCode()
        {
var userInputString =
@"myuser
Mypassword
myuser
Mypassword

userforincorrecttest
Correctpassword
userforincorrecttest
Incorrectpassword

userforshortpasswordtest
Short
userforshortpasswordtest
Correctlength
userforshortpasswordtest
Correctlength

userforpasswordcannotbeempty

userforpasswordcannotbeempty
NotEmpty
userforpasswordcannotbeempty
NotEmpty
";
            
            Console.SetIn(new StringReader(userInputString));
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //When I run through the 4 cases
            Program.Main(new string[0]);
            Program.Main(new string[0]);
            Program.Main(new string[0]);
            Program.Main(new string[0]);

            //Then
            var expectedConsoleOutput =
            @"Enter your user name
Enter your new password:
Enter your user name
Enter your password:
Correct password
Enter your user name
Enter your new password:
Enter your user name
Enter your password:
Incorrect password
Enter your user name
Enter your new password:
Should be at least 6 chars. Try again.
Enter your user name
Enter your new password:
Enter your user name
Enter your password:
Correct password
Enter your user name
Enter your new password:
Password cannot be empty. Try again.
Enter your user name
Enter your new password:
Enter your user name
Enter your password:
Correct password
";
            Assert.AreEqual(expectedConsoleOutput, consoleOutput.ToString());
        }
    }
}

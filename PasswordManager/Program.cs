using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddOrChangePassword();
            CheckPassword();
            Console.ReadLine();
        }

        public static void AddOrChangePassword()
        {
            //input user name
            Console.WriteLine("Enter your user name");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("User name cannot be empty. Try again.");
                //try again
                AddOrChangePassword();
                return;
            }

            //input password
            Console.WriteLine("Enter your new password:");
            string password = Console.ReadLine();

            //Validate password criteria

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty. Try again.");
                //try again
                AddOrChangePassword();
                return;
            }
            else if (password.Length < 6)
            {
                Console.WriteLine("Should be at least 6 chars. Try again.");
                //try again
                AddOrChangePassword();
                return;
            }

            //Calculate hash
            byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));

            //Save password
            File.WriteAllBytes(username, hash);
        }

        public static void CheckPassword()
        {
            //input user name and password
            Console.WriteLine("Enter your user name");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            //Calculate hash
            byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] savedHash = null;

            try
            {
                savedHash = File.ReadAllBytes(username);
            }
            catch (Exception)
            { /*gulp*/}

            if (hash == null || savedHash == null || savedHash.SequenceEqual(hash))
            {
                Console.WriteLine("Correct password");
            }
            else
            {
                Console.WriteLine("Incorrect password");
            }
        }
    }
}

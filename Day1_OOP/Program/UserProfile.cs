using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace Day1_OOP.Program
{

    public class UserProfile
    {
        public string Username { get; set; }
        public string? Email { get; set; }

        // using private access modifier for sensitive information
        private string? Password;

        public UserProfile(string username, string email , string password)
        {
            Username = username;
            if (IsEmailValid(email))
            {
                Email = email;
                Console.WriteLine("Email is valid.");
            }
            if (IsPasswordValid(password))
            {         
                Password = password;
                Console.WriteLine("Password is valid.");
            }
        
        }

        static void CW(string message)
        {
            Console.WriteLine(message);
        }
        private bool IsPasswordValid(string password)
        {
            if (password.Length < 6)
            {
                CW("Password must be at least 6 characters long.");
                return false;
            }
            return true;
        }
        private bool IsEmailValid(string email)
        {
            try
            {
                // can use regular expressions for more complex validation
                var emailAddress = new MailAddress(email);
                return emailAddress.Address == email;
            }
            catch (FormatException) 
            {
                CW("Invalid email format.");
                return false;
            }
        }
        public void DisplayProfile()
        {
            CW($"Username: {Username}");
            CW($"Email: {Email}");
        }
        
        public string? GetPassword(string email)
        {
            // simple authentication check, to verify email
            if (email == Email)
            {

                return Password;
            }
            else
            {
                CW("Email does not match. Access denied.");
            }
            return null;
        }
    }

    public class User {

        public static void Main(string[] args)
        {
            UserProfile p1 = new UserProfile("user1", "useamp@le", "password123");
            p1.DisplayProfile();
            string? password  = p1.GetPassword("useamp@lefdsf");
            Console.WriteLine(password);
        }
    }
}

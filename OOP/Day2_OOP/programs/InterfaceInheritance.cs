using System;
using System.Collections.Generic;
using System.Text;

namespace Day2_OOP.programs
{
    //currently using void as the return data type but, can use a DTO like User, or Admin
    interface IUser
    {

        void ViewData(string token);
        void CreateUser(string token);

    }

    interface IAdminUser : IUser
    {
        void EditData(string token, string data);
        void GetAdmins(string token);
    }

    class User : IUser
    {
        public void CreateUser(string token)
        {
            Console.WriteLine("User created by token: " + token);
        }
        public void ViewData(string token)
        {
            Console.WriteLine("Data Viewed ");
        }
    }

    // AdminUser inherits user functionalities from User class 
    class AdminUser : User, IAdminUser
    {

        public void EditData(string token, string data)
        {
            Console.WriteLine("Admin edited data: " + this.ToString());
        }
        public void GetAdmins(string token)
        {
            Console.WriteLine("Admin list fetched by token");
        }
    }
    internal class InterfaceInheritance
    {
        public static void Main()
        {
            IUser user = new User();
            user.CreateUser("user-token-123");
            user.ViewData("user-token-123");
            IAdminUser admin = new AdminUser();
            admin.CreateUser("admin-token-456");
            admin.ViewData("admin-token-456");
            admin.EditData("admin-token-456", "Important Data");

        }
    }
}

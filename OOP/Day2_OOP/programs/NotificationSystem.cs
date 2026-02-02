using System;
using System.Collections.Generic;
using System.Text;

namespace Day2_OOP.programs
{
    internal interface INotification
    {
        bool NotifyMessage(string message);
        
    }

    class EmailNotificationService : INotification
    {

        public virtual bool NotifyMessage(string message) {
            if (message.Length > 0)
            {
            Console.WriteLine("SENDING.. EMAIL");
            /*  
             *  SMS api call 
             *  EmailService.SendEmail(message, "sender_email" , "receiver_email");
             *  
             */
            Console.WriteLine("EMAIL SENT SUCCESSFULLY");
            return true;
            }
            else {
                return false;
            }
        }


    }
    class SMSNotificationService : INotification {
        public virtual bool NotifyMessage(string message)
        {
            Console.WriteLine("SENDING SMS.. MESSAGE");
            /*  
             *  SMS api call 
             *  sendSMS(message, "9999999999");
             *  
             */
            Console.WriteLine("MESSAGE SENT SUCCESSFULLY");

            return true;
        }
    }

    internal class NotificationSystem
    {

        public static void Main()
        {
            string message = "hello, everyone!\nHope You are good!";
        INotification emailnotification = new EmailNotificationService();
        emailnotification.NotifyMessage(message);
        INotification smsnotification = new SMSNotificationService();
            smsnotification.NotifyMessage(message);

        }
        
    }
}

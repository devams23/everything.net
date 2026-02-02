using System;
using System.Collections.Generic;
using System.Text;

namespace Day2_OOP.programs
{

    internal class AppConfig
    {
        /*
         * instead of readonly we can also do, AppName {get;}
         */
        //public readonly string? AppName;
        //public readonly string? AppVersion;
        //public readonly DateTime? CreatedAt;

        public  string? AppName { get; }
        public  string? AppVersion { get; }
        public  DateTime? CreatedAt{ get; }
        internal AppConfig(string appname, string appversion)
        {
            AppName = appname;
            AppVersion = appversion;
        }
        internal AppConfig(string appname, string appversion, DateTime createdat)
        {
            AppName = appname;
            AppVersion = appversion;
            CreatedAt = createdat;
        }
        internal void DisplayAppInfo()
        {
            Console.WriteLine("app info:\n"+"Name: "+ AppName + "\nVersion: "+ AppVersion + "\nCreated at: "+ CreatedAt);
        }
    }
    internal class AppProgram{
        public static void Main(string[] args) {

            AppConfig appconfig = new AppConfig("APP1" , "v1.1.9");
            AppConfig appconfig1 = new AppConfig("APP2", "v1.1.3", DateTime.Now);


            // cannot assign new values -- readonly field
            //appconfig.AppVersion = "dsasdfs"; 
            appconfig1.DisplayAppInfo();
        }
    }
}

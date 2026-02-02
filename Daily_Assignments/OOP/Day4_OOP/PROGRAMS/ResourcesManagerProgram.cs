using System;
using System.IO;

namespace Day4_OOP.PROGRAMS
{
    // using IDisposable interface , to manage resources
    class FileHandler : IDisposable
    {
        private StreamWriter writer;

        public FileHandler(string path)
        {
            writer = new StreamWriter(path);
            Console.WriteLine("File opened.");
        }

        public void WriteFile()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Writing log message " + i);
                    writer.WriteLine("LOG MESSAGE::" + i);
                    Console.WriteLine("Log message " + i + " written to file.");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("FILEHANDLER::WRITEFILE---IO EXCEPTION OCCURED" + ex.Message);
            }
        }

        // ensuring that file is always closed properly
        public void Dispose()
        {
            if (writer != null)
            {
                writer.Close();
                Console.WriteLine("File closed.");
            }
        }
    }

    internal class ResourcesManagerProgram
    {
         
        public static void Main()
        {
            string filePath = "D:\\bacancy_training\\.net\\Assignments\\Day4_OOP\\PROGRAMS\\test.log";

            // Using 'using' statement, here the dispose method will be called automatically
            using (FileHandler fhUsing = new FileHandler(filePath))
            {
                fhUsing.WriteFile();
            }

            // Manual disposal of resources
            FileHandler fhManual = new FileHandler(filePath);
            fhManual.WriteFile();
            fhManual.Dispose();

        }
    }

}

                


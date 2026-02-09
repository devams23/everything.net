// File created on 5/02/2026
namespace TASK_PRACTISE.Programs
{
    class Program
    {
        public static async Task<string> GetUserProileAsync()
        {
            Console.WriteLine("fetching profile data");
            await Task.Delay(2000);
            Console.WriteLine("end");
            return "profile";
        }
        public static async Task<string> GetUserOrdersAsync()
        {
            Console.WriteLine("fetching Orders data");
            await Task.Delay(4000);       
            Console.WriteLine("end");
            return "orders";
        }
        static async Task Main(string[] args)
        {
            Task<string> output = GetUserOrdersAsync();
            Task<string> output2 = GetUserProileAsync();

            Console.WriteLine("Still running");

            Console.WriteLine(await output);
            Console.WriteLine("-----------");
            Console.WriteLine(await output2);
        }

    }
}

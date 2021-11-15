using System;
using System.Threading.Tasks;

namespace Asyncaw
{
    class Program
    {
        static async Task<int> MMain() { 
             Console.WriteLine("3");
            return 2;
        }

        static void Main() => MMain().GetAwaiter().GetResult();
    }
}

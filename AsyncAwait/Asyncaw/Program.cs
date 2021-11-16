using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asyncaw
{
    class Program
    {
        static   int Main()
        {
            Console.WriteLine("Start Main");
            var awaiter =   GetMain();
            Console.WriteLine("wait awaiter 1");

            Thread.Sleep(300);

            Console.WriteLine("wait awaiter 2");
            var rt =  awaiter.GetAwaiter();

            Console.WriteLine("wait awaiter 3");
            Thread.Sleep(6000);
            Console.WriteLine("wait awaiter 4");

            rt.GetResult();
            Console.WriteLine("End Main");
            Console.ReadLine();
            return 0;
        }

        static async Task<int> GetMain() {


            Console.WriteLine("Start A");
            var tt = Task.Run(() => SomeTaskA());
            Console.WriteLine("Start 2 ");
            var t1 =   Task.Run(() => SomeTask2());
            Console.WriteLine("Start 0 ");
            var t2 =   Task.Run(() => SomeTask0());

            Console.WriteLine("End start" );

            Console.WriteLine("await A ");
            await tt;
            Console.WriteLine("await 2 ");
            var ti1 = await t1;
            Console.WriteLine("await 0 ");
            var ti2 = await t2;
            Console.WriteLine("End await");
            return 0;
        }


        static async void SomeTaskA()
        {
            Console.WriteLine("start A second");

            var t3 =  Task.Run(() => SomeTask3());
            var t1 = Task.Run(() => SomeTask1());
            Console.WriteLine("Wait SUB 1");
            await t1;
            Console.WriteLine("Wait SUB 3");
            await t3;
            Console.WriteLine("finish A second");
       
        }
        static async Task<int> SomeTask0()
        {
            Console.WriteLine("start 0 second");
            await Task.Run(() => Thread.Sleep(200));

            Console.WriteLine("finish 0 second");
            return 0;
        }

        static async Task<int> SomeTask1() {
            Console.WriteLine("start SUB 1 second"); 
            await Task.Run(()=>Thread.Sleep(1100));
            Console.WriteLine("finish SUB 1 second");
            return 1;        
        }

        static async Task<int> SomeTask2()
        {
            Console.WriteLine("start 2 second");
            await Task.Run(() => Thread.Sleep(1400));

            Console.WriteLine("finish 2 second");
            return 2;
        }

        static async Task<int> SomeTask3()
        {
            Console.WriteLine("start SUB 3 second");
            await Task.Run(() => Thread.Sleep(3000));

            Console.WriteLine("finish SUB 3 second");
            return 3;
        }

    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Situation 1: .Result");
            Console.WriteLine(LongTask().Result);
            DoSomethingElse();
            Console.WriteLine();

            Console.WriteLine("Situation 2: .ConfigureAwait(false)");
            Console.WriteLine(await LongTask().ConfigureAwait(false));
            DoSomethingElse();
            Console.WriteLine();

            Console.WriteLine("Situation 3: await");
            Console.WriteLine(await LongTask());
            DoSomethingElse();
            Console.WriteLine();

            Console.WriteLine("Situation 4: .Result after long task");
            var task1 = LongTask();
            DoSomethingElse();
            Console.WriteLine(task1.Result);
            Console.WriteLine();

            Console.WriteLine("Situation 5: .ConfigureAwait(false) after long task");
            var task2 = LongTask().ConfigureAwait(false);
            DoSomethingElse();
            Console.WriteLine(await task2);
            Console.WriteLine();

            Console.WriteLine("Situation 6: await after long task");
            var task3 = LongTask();
            DoSomethingElse();
            Console.WriteLine(await task3);
            Console.WriteLine();

            Console.WriteLine("Situation 7: .Result with exception");
            try
            {
                var task4 = LongTaskWithException();
                DoSomethingElse();
                Console.WriteLine(task4.Result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine();
            }

            Console.WriteLine("Situation 8: .ConfigureAwait(false) with exception");
            try
            {
                var task5 = LongTaskWithException().ConfigureAwait(false);
                DoSomethingElse();
                Console.WriteLine(await task5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine();
            }

            Console.WriteLine("Situation 9: await with exception");
            try
            {
                var task6 = LongTaskWithException();
                DoSomethingElse();
                Console.WriteLine(await task6);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static async Task<string> LongTask() 
        { 
            await Task.Delay(500);
            return "LongTask2 done";
        }

        private static async Task<int> LongTaskWithException() 
        { 
            await Task.Delay(500);
            throw new NotSupportedException("Test exception");
        }
        
        private static void DoSomethingElse()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine();
        }
    }
}

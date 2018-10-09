using System;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    class AsyncAwait
    {
        static void Main(string[] args)
        {
            TaskWork();

            // gets the result from finishing the Task
            Console.WriteLine($"finished");
        }

        static async void TaskWork()
        {
            await Task.Run(() =>
            {
                long sum = 0;

                for (int i = 0; i < 2000000; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"The sum is: {sum}");
            });
        }
    }
}

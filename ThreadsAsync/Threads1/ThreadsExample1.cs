using System;
using System.Threading;

namespace Threads1
{
    class ThreadsExample1
    {
        static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"{i}");
                }

            });
            thread.Start();
            thread.Join();

            var thread1 = new Thread(() =>
            {
                for (int j = 1000; j < 1100; j++)
                {
                    Console.WriteLine($"{j}");
                }
            });
            thread1.Start();
            thread1.Join();

            for (int z = 100000; z < 100100; z++)
            {
                Console.WriteLine($"{z}");
            }
        }
    }
}

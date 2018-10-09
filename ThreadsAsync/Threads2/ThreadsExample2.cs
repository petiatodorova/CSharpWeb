using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Threads2
{
    class ThreadsExample2
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            var thread = new Thread(() =>
            {
                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"{i}");
                    }
                }
            });

            thread.Start();
            thread.Join();
            Console.WriteLine($"Thread finished work");
        }
    }
}

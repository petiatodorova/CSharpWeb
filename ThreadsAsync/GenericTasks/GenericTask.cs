using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTasks
{
    class GenericTask
    {
        static void Main(string[] args)
        {
            var task = Task.Run(() =>
            {
                long sum = 0;

                for (int i = 0; i < 100000; i++)
                {
                    sum += i;
                }

                return sum;
            });

            // gets the result from finishing the Task
            Console.WriteLine($"{task.Result}");
        }
    }
}

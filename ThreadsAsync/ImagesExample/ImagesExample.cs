using System;

using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagesExample
{
    class ImagesExample
    {
        static void Main(string[] args)
        {
            var files = new DirectoryInfo("../../Images").GetFiles();

            var tasks = new List<Task>();

            int step = 0;

            foreach (var file in files)
            {
                // if we want first to finish the current Task and then to go on with the next Task
                Task.Run(() =>
                {
                    var image = Image.FromFile(file.FullName);

                    image.RotateFlip(RotateFlipType.Rotate180FlipX);

                    image.Save(file.FullName + "_rotated");
                }).GetAwaiter().GetResult();

                Console.WriteLine($"Step: {step} is finished.");
                step++;
            }


            // if we want to run all Tasks after they are added to our list
            //foreach(var file in files)
            //{
            //    var task = Task.Run(() =>
            //    {
            //        var image = Image.FromFile(file.FullName);

            //        image.RotateFlip(RotateFlipType.Rotate180FlipX);

            //        image.Save(file.FullName + "_rotated");
            //    });

            //    tasks.Add(task);

            //}

            Task.WaitAll(tasks.ToArray());
        }
    }
}

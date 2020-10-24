using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zadanie1B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 1, 2, 3, 4, 5, 6 };
            Stopwatch stopwatch = new Stopwatch();

            StreamReader sr = new StreamReader("./A3.txt");

            long time = 0;
            int steps = 0;

            bool isNonDecreasing = true;

            stopwatch.Start();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                steps++;

                if (arr[i] > arr[i + 1])
                {
                    isNonDecreasing = false;
                    break;
                }


            }

            stopwatch.Stop();

            time = stopwatch.ElapsedTicks;

            stopwatch.Reset();

            Console.WriteLine("Czy niemalejacy: " + isNonDecreasing);
            Console.WriteLine("Ticki: " + time);
            Console.WriteLine("Krokow: " + steps);
            Console.ReadLine();
        }
    }
}

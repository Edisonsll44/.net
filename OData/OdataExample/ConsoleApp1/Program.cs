using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(i.ToString());
            }
            sw.Stop();
            long elapsed = sw.ElapsedMilliseconds; // or sw.ElapsedTicks
            Console.WriteLine("Total query time: {0} ms", elapsed);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

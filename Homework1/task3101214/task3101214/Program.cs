using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3101214
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int code = rd.Next (97, 122);
            ConsoleKeyInfo key;
            Stopwatch stopwatch = new Stopwatch();
            
            //task is given
            Console.WriteLine("Enter a symbol!");
            Console.WriteLine(Convert.ToChar(code));
           
            //start time counting
            stopwatch.Start();
            key = Console.ReadKey(); //read user's input
            Console.WriteLine();
            if (Convert.ToChar(code) == key.KeyChar)
                Console.WriteLine("Correct!");
            else
                Console.WriteLine("Try again!");
           
            stopwatch.Stop(); // end time counting
            TimeSpan ts = stopwatch.Elapsed;
            
            //showing the result
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

       }
    }
}

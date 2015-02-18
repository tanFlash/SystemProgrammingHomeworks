using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace task1101214
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> col = new List<int> { 1, 2, 3, 4, 5, };

            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(ListMethod);
            Thread thread = new Thread(threadstart);
            thread.Start((object)col);
        }

        static void ListMethod(object list)
        {
            List<int> ourList = (List<int>)list;
            foreach (int i in ourList)
                Console.WriteLine(i.ToString()); 

        }
    }
}

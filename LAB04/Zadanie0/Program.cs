using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie0
{
    class Program
    {
        static int fun1(int n)
        {
            if (n == 1)
                return 0;
            else
                return 1 + fun1(n / 2);
        }

        //Złozonosc: O(log n)

        static void Main(string[] args)
        {
            Console.WriteLine(fun1(23));
        }
    }
}

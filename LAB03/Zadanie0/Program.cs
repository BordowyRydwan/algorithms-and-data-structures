using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie0
{
    class Program
    {
        static int NWD(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }

            return NWD(b, a % b);
        }

        static void Main(string[] args)
        {

            Console.WriteLine(NWD(147, 14));
            Console.ReadKey();
        }
    }
}

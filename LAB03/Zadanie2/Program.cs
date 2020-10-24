using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static int[] Reszta(int[] n, int r)
        {
            int[] m = new int [n.Length];
            int k = 0;

            while(r > 0)
            {
                if (r >= n[k])
                {
                    r -= n[k];
                    m[k]++;
                }

                else
                {
                    k++;
                }
            }

            return m;
        }


        static void Main(string[] args)
        {
            int[] n = { 50, 25, 20, 10, 5, 1 };
            int[] m = Reszta(n, 40);

            for(int i = 0; i < m.Length; ++i)
            {
                Console.WriteLine(n[i] + " sztuk " + m[i]);
            }

            Console.ReadKey();
        }
    }
}

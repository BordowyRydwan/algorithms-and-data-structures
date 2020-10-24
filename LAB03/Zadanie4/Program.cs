using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Reszta(int[] monety, int reszta)
        {
            int[] minLiczbaMonet = new int[reszta + 1];
            int[] ostatniaMoneta = new int[reszta + 1];

            ostatniaMoneta[0] = -1;
            minLiczbaMonet[0] = 0;

            for(int m = 1; m <= reszta; m++)
            {
                minLiczbaMonet[m] = Int32.MaxValue;

                for(int i = 0; i < monety.Length; ++i)
                {
                    if(m >= monety[i])
                    {
                        if(minLiczbaMonet[m - monety[i]] + i < minLiczbaMonet[m])
                        {
                            minLiczbaMonet[m] = minLiczbaMonet[m - monety[i]] + 1;
                            ostatniaMoneta[m] = i;
                        }
                    }
                }
            }

            Console.WriteLine(minLiczbaMonet[reszta]);

            int[] ileMonet = new int[monety.Length];

            for(int i = 0; i < ileMonet.Length; ++i)
            {
                ileMonet[i] = 0;
            }

            int mm = reszta;

            while(mm > 0)
            {
                ileMonet[ostatniaMoneta[mm]]++;
                mm -= monety[ostatniaMoneta[mm]];
            }

        }


        static void Main(string[] args)
        {
            int[] n = { 50, 25, 20, 10, 5, 1 };

            Reszta(n, 40);

            Console.ReadKey();
        }
    }
}

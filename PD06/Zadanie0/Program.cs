using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static int Nagroda(int n, int m, int[,] dol, int[,] prawo, int[,] k)
        { 
            int[,] s = new int[n + 1, m + 1];
            s[0, 0] = 0;

            //pierwsza kolumna
            for(int i = 1; i <= n; ++i)
            {
                s[i, 0] = s[i - 1, 0] + dol[i - 1, 0];
                k[i, 0] = 1; //góra
            }

            //pierwszy wiersz
            for (int i = 1; i <= m; ++i)
            {
                s[0, i] = s[0, i - 1] + dol[0, i - 1];
                k[0, i] = 2; //lewo
            }

            //wypelnianie
            for (int i = 1; i <= n; ++i)
            {
                for(int j = 1; j <= m; ++j)
                {
                    s[i, j] = Math.Max(s[i - 1, j] + dol[i - 1, j], s[i, j - 1] + prawo[i, j - 1]);

                    if(s[i, j] == s[i - 1, j] + dol[i - 1, j])
                    {
                        k[i, j] = 1;
                    }

                    if (s[i, j] == s[i, j - 1] + prawo[i, j - 1])
                    {
                        k[i, j] = 2;
                    }
                }
            }

            return s[n, m];
        }

        static void Odtworzenie(int n, int m, int[,] dol, int[,] prawo, int[,] k)
        {
            int i = n;
            int j = m;

            int[] przesuniecia = new int[n + m];
            int[] wartosci = new int[n + m];

            int l = n + m - 1;

            while (i > 0 || j > 0) {

                if (k[i, j] == 2)
                {
                    przesuniecia[l] = 2;
                    wartosci[l] = prawo[i, j - 1];
                    l--;
                    j--;
                }

                if (k[i, j] == 1)
                {
                    przesuniecia[l] = 1;
                    wartosci[l] = dol[i - 1, j];
                    l--;
                    i--;
                }

            }

            for (l = 0; l < n + m; ++l)
            {
                if (przesuniecia[l] == 1)
                {
                    Console.WriteLine("dol " + wartosci[l]);
                }

                if (przesuniecia[l] == 2)
                {
                    Console.WriteLine("prawo " + wartosci[l]);
                }
            }
        }

        static void Main(string[] args)
        {
            int n = 4;
            int m = 4;

            int[,] down = {
                {1,0,2,4,3},
                {3,6,5,2,1},
                {4,4,5,2,1},
                {5,6,8,5,3},
            };

            int[,] right = {
                {3,2,4,0},
                {3,2,4,2},
                {0,7,3,4},
                {3,3,0,2},
                {1,3,2,2},
            };

            int[,] kroki = new int[n + 1, m + 1];

            Console.WriteLine(Nagroda(n, m, down, right, kroki));
            Odtworzenie(n, m, down, right, kroki);
            Console.ReadKey();

        }
    }
}

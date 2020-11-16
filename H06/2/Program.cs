using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static int[] Plecak(int[] w, int[] c, int[,] wynik, int n, int k)
        {
            int i, j;
            int[,] kroki = new int[n + 1, k + 1];

            for (i = 0; i <= k; ++i)
            {
                wynik[0, i] = 0;
            }

            for (j = 1; j <= n; ++j)
            {
                for (i = 0; i <= k; ++i)
                {
                    wynik[j, i] = wynik[j - 1, i]; // nie gorzej niz dla j - 1 przedmiotow
                    kroki[j, i] = 1; // z gory

                    if ((i >= 1) && (wynik[j, i - 1] > wynik[j, i])) //nie gorzej niz dla najmniejszego plecaka
                    {
                        wynik[j, i] = wynik[j, i - 1];
                        kroki[j, i] = 2; //z lewej
                    }

                    if ((i >= w[j - 1]) && (wynik[j - 1, i - w[j - 1]] + c[j - 1] > wynik[j, i]))
                    {
                        wynik[j, i] = wynik[j - 1, i - w[j - 1]] + c[j - 1];
                        kroki[j, i] = 3; //skos
                    }
                }
            }

            int[] przedmioty = new int[n];

            for (i = 0; i < n; ++i)
            {
                przedmioty[i] = 0;
            }

            i = k;
            j = n;

            while (i >= 0 && j > 0)
            {
                if(kroki[j, i] == 1)
                {
                    j -= 1;
                }
                else if (kroki[j, i] == 2)
                {
                    i -= 1;
                }
                if (kroki[j, i] == 3)
                {
                    przedmioty[j - 1] = 1;
                    i = i - w[j - 1];
                    j = j - 1;
                }
            }

            return przedmioty;
        }

        static void Main(string[] args)
        {
            int n = 5;
            int k = 50;

            int[] wielkosc = { 16, 15, 10, 5, 7 };
            int[] cena = { 8, 7, 6, 9, 3 };

            int[,] wynik = new int[n + 1, k + 1];

            int[] ktore = Plecak(wielkosc, cena, wynik, n, k);
            Console.WriteLine("Razem wartosc " + wynik[n, k]);

            for(int i = 0; i < n; ++i)
            {
                if(ktore[i] == 1)
                {
                    Console.WriteLine("wielkosc {0} wartosc {1}", wielkosc[i], cena[i]);
                }
            }

            Console.Read();
        }
    }
}

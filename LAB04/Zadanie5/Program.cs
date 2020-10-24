using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5
{
    class Program
    {
        static void Scalaj(int[] T, int p, int mid, int k, int[] T2)
        // p - poczatek, k - koniec, mid - srodek
        // łączy 2 posortowane tablice T[p...mid] i T[mid+1...k]
        {
            int p1 = p, k1 = mid; // pod-tablica 1
            int p2 = mid + 1, k2 = k; // pod-tablica 2
                                      // aż do wyczerpania tablic dokonaj scalenia przy pomocy tablicy pomocniczej
            int i = p1;
            while ((p1 <= k1) && (p2 <= k2))
            {
                if (T[p1] < T[p2])
                { T2[i] = T[p1]; p1++; }
                else
                { T2[i] = T[p2]; p2++; }
                i++;
            }
            while (p1 <= k1)
            {
                T2[i] = T[p1]; p1++; i++;
            }
            while (p2 <= k2)
            {
                T2[i] = T[p2]; p2++; i++;
            }
            // skopiuj z tablicy tymczasowej do oryginalnej
            for (i = p; i <= k; i++) T[i] = T2[i];
        }

        static void MergeSort(int[] T, int[] P)
        {
            int n = T.Length;
            int i, j, p, mid, k;

            for(i = 1; i < n; i = 2 * i)
            {
                for(j = 0; j < n - 1; j = j + 2 * i)
                {
                    p = j;
                    k = j + 2 * i - 1;

                    if (k >= n) k = n + 1;

                    mid = j + i - 1;

                    Console.WriteLine(p + " " + mid + " " + k);
                    Scalaj(T, p, mid, k, P)
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}

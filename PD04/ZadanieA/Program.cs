using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieA
{
    class Program
    {
        //Zlozonosc: O(n*log(n))

        //Przy wykonywaniu zadania A przypadkowo opracowałem algorytm działający identycznie do tego algorytmu z zadania C.
        //Różnił się wyłącznie tym, że pivot był losowym indeksem tablicy, a nie w połowie
        //Dla porządku, projekt z zadaniem C zawiera podobny kod, co w A

        static int MojPodzial(int[] T, int l, int p, int pivot)
        {
            while (l <= p)
            {
                while(T[l] < pivot)
                {
                    l++;
                }

                while (T[p] > pivot)
                {
                    p--;
                }

                if(l <= p)
                {
                    int tmp = T[l];
                    T[l] = T[p];
                    T[p] = tmp;
                    l++;
                    p--;
                }
            }

            return l;
        }

        static void QuickSort(int[] T, int l, int p)
        {
            if (l >= p) return;

            int randomIndex = new Random().Next(l, p);
            int pivot = T[randomIndex];
            int i = MojPodzial(T, l, p, pivot);
            QuickSort(T, l, i - 1);
            QuickSort(T, i, p);
        }

        static void Main(string[] args)
        {
            int[] arr1 = { -19, 1, 1, 8, 7, -5, 3, 5, 4, 6 };

            QuickSort(arr1, 0, arr1.Length - 1);

            foreach (int num in arr1)
            {
                Console.Write(num + ", ");
            }

            Console.ReadKey();
        }
    }
}

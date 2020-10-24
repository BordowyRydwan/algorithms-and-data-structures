using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        //Zlozonosc: O(n*log(n))

        static int Podzial(int[] T, int l, int p)
        {
            int i, j, klucz, tmp, index;
            // wybierz element centralny
            index = p; // bierzemy prawy,
                       // może być dowolny element z przedziału, wtedy najpierw zamiana z prawym
            klucz = T[index];
            i = l;// na lewo od indeksu i elementy <= klucz
            for (j = l; j < p; j++)
            {
                if (T[j] <= klucz) // zamień
                {
                    tmp = T[i];
                    T[i] = T[j];
                    T[j] = tmp;
                    i++;
                }
            }
            // wstaw element centralny na swoje miejsce
            tmp = T[i];
            T[i] = T[p];
            T[p] = tmp;
            return i;
        }

        static void QuickSort(int[] T, int l, int p)
        {
            if (l >= p) return;
            int i = Podzial(T, l, p);
            QuickSort(T, l, i - 1);
            QuickSort(T, i + 1, p);
        }

        static void Main(string[] args)
        {
            int[] arr1 = { -19, 1, 1, 8, 7, -5, 3, 5, 4, 6 };
            int[] arr2 = { 1, 2, 3, 4, 6, 7, 8, 17, 25, 29 };
            int[] arr3 = { 19, 10, 5, 4, 3, 1, 0, -1, -2, -5 };
            int[] arr4 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] arr5 = { 1, 8, 7, -5, 3, 5, 4, 6, 2, 9 };

            QuickSort(arr1, 0, arr1.Length - 1);

            foreach (int num in arr1)
            {
                Console.Write(num + ", ");
            }

            Console.ReadKey();
        }
    }
}

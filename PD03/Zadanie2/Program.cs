using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        /*
            Wzor rekurencyjny: 

                T(1) = 1;

                Pesymistyczny przypadek (wynik jest wiecznie w środku przedziału):
                T(n) = T(n/3) + 4
        */

        static int TernarySearch(int[] arr, int left, int right, int number)
        {
            if(right >= left)
            {
                int mid1 = left + (right - left) / 3;
                int mid2 = mid1 + (right - left) / 3;

                if (arr[mid1] == number)
                {
                    return mid1;
                }

                if (arr[mid2] == number)
                {
                    return mid2;
                }

                if (number < arr[mid1])
                {
                    return TernarySearch(arr, left, mid1 - 1, number);
                }

                if (number > arr[mid2])
                {
                    return TernarySearch(arr, mid2 + 1, right, number);
                }

                return TernarySearch(arr, mid1 + 1, mid2 - 1, number);
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int[] arr = {2,6,8,13,17,18,20,22, 78, 90, 172, 189};

            for(int i = 0; i < arr.Length; ++i)
            {
                Console.WriteLine(i + ") Index: " + TernarySearch(arr, 0, arr.Length - 1, arr[i]));
            }

            Console.ReadKey();
        }
    }
}

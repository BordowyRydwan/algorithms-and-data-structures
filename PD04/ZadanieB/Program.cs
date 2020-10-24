using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieB
{
    class Program
    {
        //Zlozonosc: O(n*log(n))

        

        static void Main(string[] args)
        {
            int[] arr1 = { -19, 1, 1, 8, 7, -5, 3, 5, 4, 6 };

            QuickSort(arr1, 0, arr1.Length);

            foreach (int num in arr1)
            {
                Console.Write(num + ", ");
            }

            Console.ReadKey();
        }
    }
}


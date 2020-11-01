using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void SelectionSort(int[] arr) 
        {
            for (int beginIndex = 0; beginIndex < (arr.Length - 1) / 2; ++beginIndex)
            {
                int minIndex = beginIndex;
                int maxIndex = arr.Length - beginIndex - 1;

                
                for(int currIndex = beginIndex + 1; currIndex < arr.Length; ++currIndex)
                {
                    if(arr[currIndex] < arr[minIndex])
                    {
                        minIndex = currIndex;
                    }
                }

                for (int currIndex = arr.Length - beginIndex - 1; currIndex > 0; --currIndex)
                {
                    if (arr[currIndex] > arr[maxIndex])
                    {
                        maxIndex = currIndex;
                    }
                }


                int tmp = arr[beginIndex];
                arr[beginIndex] = arr[minIndex];
                arr[minIndex] = tmp;

                tmp = arr[arr.Length - beginIndex - 1];
                arr[arr.Length - beginIndex - 1] = arr[maxIndex];
                arr[maxIndex] = tmp;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 2, 1, 3, 7, 6, 9, 4, 5};
            int[] arr2 = { 8, 3, 6, 2, 7, 9 };

            SelectionSort(arr);
            SelectionSort(arr2);

            foreach (int i in arr)
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine();

            foreach (int i in arr2)
            {
                Console.Write(i + ", ");
            }

            Console.Read();
        }
    }
}

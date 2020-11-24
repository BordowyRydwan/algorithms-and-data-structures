using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        //sortuję malejąco

        /*
        Wyjasnienie:
        sortuję tablicę intów, która odpowiada permutacjom tablicy stringów (domyslnie to permutacje samej siebie - bedzie
        miała postać {0, ... ,strArr.Length - 1}. Zamiast jednak porównywać inty ze sobą, to porównuję ze sobą alfabetycznie stringi. Zgodnie
        z tym, że przyjąłem, że sortuję malejąco, to Z - pierwszy element alfabetu, A - ostatni. Po porowananiu zamieniam zamiast stringow, to odpowiadajaca
        jej tablice intow

        Złożonosć taka jak tablicy merge sorta, ale jeszcze razem z porównaniem stringów - O(n^2 * log(n))
        */

        static void Merge(string[] strArr, int[] arr, int left, int mid, int right)
        {
            int leftLength = mid - left + 1;
            int rightLength = right - mid;

            int[] leftArray = new int[leftLength];
            int[] rightArray = new int[rightLength];
            int i, j;

            for (i = 0; i < leftLength; ++i)
            {
                leftArray[i] = arr[left + i];
            }

            for (j = 0; j < rightLength; ++j)
            {
                rightArray[j] = arr[mid + 1 + j];
            }

            i = 0;
            j = 0;

            int k = left;
            while (i < leftLength && j < rightLength)
            {
                int condition = String.Compare(strArr[i], strArr[j + leftLength], StringComparison.OrdinalIgnoreCase);
                //porownanie stringow ze sobą

                if (condition == -1 || condition == 0)
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }

        public static void MergeSort(string[] strArr, int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(strArr, arr, left, mid);
                MergeSort(strArr, arr, mid + 1, right);

                Merge(strArr, arr, left, mid, right);
            }
        }

        static void Main(string[] args)
        {
            string[] arr = { "Adam", "Zenek", "Barbara" };
            int[] intArr = { 0, 1, 2 };

            string[] arr2 = { "Dawid", "Dawii", "Dawww", "Daaaa", "Ddddd" };
            int[] intArr2 = { 0, 1, 2 , 3, 4};

            string[] arr3 = { "ABCDE", "BCDEA", "CDEAB", "DEABC", "EABCD" , "AAAAA"};
            int[] intArr3 = { 0, 1, 2, 3, 4, 5 };

            MergeSort(arr, intArr, 0, arr.Length - 1);
            MergeSort(arr2, intArr2, 0, arr.Length - 1);
            MergeSort(arr3, intArr3, 0, arr.Length - 1);

            foreach (int item in intArr)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();

            foreach (int item in intArr2)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            foreach (int item in intArr3)
            {
                Console.Write(item + ", ");
            }

            Console.ReadLine();
        }
    }
}

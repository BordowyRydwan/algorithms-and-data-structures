using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieB
{
    class Program
    {
        static int MojPodzial(int[] T, int l, int p, int pivot)
        {
            int[] tmpArr = new int[p - l + 1];

            for(int i = 0; i < tmpArr.Length; ++i)
            {
                tmpArr[i] = T[i + l];
            }

            int left = 0;
            int right = tmpArr.Length - 1;

            while (left <= right)
            {
                while (tmpArr[left] < pivot)
                {
                    left++;
                }

                while (tmpArr[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    int tmp = tmpArr[left];
                    tmpArr[left] = tmpArr[right];
                    tmpArr[right] = tmp;
                    left++;
                    right--;
                }
            }

            for (int i = 0; i < tmpArr.Length; ++i)
            {
                T[i + l] = tmpArr[i];
            }

            return l + left;
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

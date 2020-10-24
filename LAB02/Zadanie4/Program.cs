using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static class Sortowanie
{
    public static Tuple<int[], int, int> Babelkowe(int[] arr)
    {
        int steps = 0;
        int swaps = 0;

        for (int i = 0; i < arr.Length - 1; ++i)
        {
            bool isSorted = true;

            for (int j = 0; j < arr.Length - 1; ++j)
            {
                steps++;

                if(arr[j] > arr[j + 1])
                {
                    int tmp = arr[j];

                    isSorted = false;

                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                    swaps++;
                }
            }

            if (isSorted)
            {
                break;
            }
        }

        return new Tuple<int[], int, int>(arr, steps, swaps);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] arr1 = { 3, 6, 8, 2, 0, 5, 9 };
        Tuple<int[], int, int> sortedArr1 = Sortowanie.Babelkowe(arr1);

        foreach(int num in sortedArr1.Item1)
        {
            Console.Write(num + ", ");
        }

        Console.WriteLine("\nKrokow: " + sortedArr1.Item2);
        Console.WriteLine("Podmian: " + sortedArr1.Item3 + "\n");

        int[] arr2 = { 0, 1, 2, 3, 4, 5, 6 };
        Tuple<int[], int, int> sortedArr2 = Sortowanie.Babelkowe(arr2);

        foreach (int num in sortedArr2.Item1)
        {
            Console.Write(num + ", ");
        }

        Console.WriteLine("\nKrokow: " + sortedArr2.Item2);
        Console.WriteLine("Podmian: " + sortedArr2.Item3 + "\n");

        int[] arr3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        Tuple<int[], int, int> sortedArr3 = Sortowanie.Babelkowe(arr3);

        foreach (int num in sortedArr3.Item1)
        {
            Console.Write(num + ", ");
        }

        Console.WriteLine("\nKrokow: " + sortedArr3.Item2);
        Console.WriteLine("Podmian: " + sortedArr3.Item3 + "\n");

        Console.ReadLine();
    }
}


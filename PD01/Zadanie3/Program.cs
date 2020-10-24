using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SearchIndexSum
{
    public static bool DoesIndexSumExist(int[] arr1, int[] arr2, int checkedNumber)
    {
        int i = 1;
        int j = arr1.Length - 1;

        while (i < arr1.Length && j > 0)
        {
            if (arr1[i] + arr2[j] == checkedNumber)
            {
                return true;
            }
            else if (arr1[i] + arr2[j] < checkedNumber)
            {
                i += 1;
            }
            else
            {
                j -= 1;
            }
        }

        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int sum1 = 8;
        int sum2 = 11;
        int[] arr1_1 = { 1, 2, 3, 4 };
        int[] arr1_2 = { 2, 5, 6, 4 };

        bool result1 = SearchIndexSum.DoesIndexSumExist(arr1_1, arr1_2, sum1); //istnieje
        bool result2 = SearchIndexSum.DoesIndexSumExist(arr1_1, arr1_2, sum2); //nie istnieje

        Console.WriteLine("Wynik testu 1 (oczekiwane: true): " + result1);
        Console.WriteLine("Wynik testu 2 (oczekiwane: false): " + result2);

        Console.Read();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ConcatArrays
{
    public static int[] ArrConcatNonDecreasing(int[] arr1, int[] arr2)
    {
        //Przyjmuję:
        //arr1.Length = m;
        //arr2.Length = n;
        //
        //Złożoność czasowa: O(n + m) - liniowa
        //Złożoność pamięciowa: O(n + m) - liniowa
        //
        //Algorytm się zawsze zakończy, bo warunkiem jego zakończenia jest 
        //pełne przeiterowanie po wcześniej zdefiniowanej tablicy o ustalonym rozmiarze.

        int len = arr1.Length + arr2.Length;
        int[] resultArr = new int[len];
        int index1 = 0;
        int index2 = 0;

        while(!((index1 == arr1.Length) || (index2 == arr2.Length)))
        {
            if(arr1[index1] <= arr2[index2])
            {
                resultArr[index1 + index2] = arr1[index1];
                index1++;
            }
            else{
                resultArr[index1 + index2] = arr2[index2];
                index2++;
            }
        }

        if(index1 == arr1.Length)
        {
            while(index2 != arr2.Length)
            {
                resultArr[index1 + index2] = arr2[index2];
                index2++;
            }

            return resultArr;
        }

        if (index2 == arr2.Length)
        {
            while (index1 != arr1.Length)
            {
                resultArr[index1 + index2] = arr1[index1];
                index1++;
            }

            return resultArr;
        }

        return resultArr;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] arr1 = { 1, 3, 4, 8, 9, 11 };
        int[] arr2 = { 2, 5, 6, 7 , 10};

        int[] concatenatedArr = ConcatArrays.ArrConcatNonDecreasing(arr1, arr2);

        foreach (int num in concatenatedArr)
        {
            Console.Write(num + ", ");
        }

        Console.Read();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 2, 2, 2, 3, 3, 1, 2, 3 , 3, 3};

        int licznik1 = 0;
        int licznik2 = 0;
        int przywodca1 = 0;
        int przywodca2 = 0;

        for (int i = 0; i < arr.Length; ++i)
        {
            if (licznik1 == 0)
            {
                ++licznik1;
                przywodca1 = arr[i];
                continue;
            }

            if (licznik2 == 0)
            {
                ++licznik2;
                przywodca2 = arr[i];
                continue;
            }

            if (przywodca1 == arr[i])
            {
                licznik1++;
                continue;
            }

            if (przywodca2 == arr[i])
            {
                licznik2++;
                continue;
            }

            licznik1--;
            licznik2--;
        }

        Console.Write("Przywodcy: " + przywodca1 + ", " + przywodca2);
        Console.ReadLine();
    }
}


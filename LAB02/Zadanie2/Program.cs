using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{

    static void Main(string[] args)
    {
        int[] arr = { 2, 2, 2, 3, 1, 2, 1};

        int ile = 0;
        int j = 0;

        for (int i = 0; i < arr.Length; ++i)
        {
            if (ile == 0)
            {
                ile += 1;
                j = i;
            }
            else if(arr[i] == arr[j]) {
                ile += 1;
            }
            else
            {
                ile -= 1;
            }
        }

        Console.Write(arr[j]);
        Console.ReadLine();
    }
}


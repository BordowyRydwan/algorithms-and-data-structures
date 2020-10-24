using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    Niezmiennik - n = const
    Warunek stopu: (a+1)^2 dąży do stałego n
*/

class Program
{
    static void Main(string[] args)
    {
        int a = 0;
        int n = 36;

        while((a+1)*(a+1) <= n)
        {
            a++;
        }

        Console.WriteLine("floor(sqrt(" + n + ")) = " + a);
        Console.Read();
    }
}


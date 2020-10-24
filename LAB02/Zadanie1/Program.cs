using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int Mnozenie(int a, int b)
    {
        int suma = 0;

        for(int i = 0; i < b; ++i)
        {
            suma += a;
        }

        return suma;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Mnozenie(4, 7));
        Console.ReadLine();

        /*
            WARUNEK STOPU:
            
            Algorytm się skończy, bo w każdej pętli i dąży do b.
            Niezmiennik: suma == i * b
        */
    }
}

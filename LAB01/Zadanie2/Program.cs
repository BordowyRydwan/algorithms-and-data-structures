using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Euklides
{
    public static int NWD_Odejmowanie(int m, int n, ref int k)
    {
        while (n > 0) // na starcie obie wartości są dodatnie
        {
            k++;
            int t = m;

            if (m > n) //zamiana
            {
                
                m = n;
                n = t;
            }
            n = n - m;
        }
        return m;
    }

    public static int NWD_Dzielenie(int m, int n, ref int k)
    {
        while (n > 0)
        {
            k++;
            int t = m;
            m = n;
            n = t % n; // jeśli m<n to t%n da m, czyli nastąpi zamiana
        }

        return m;
    }

}


class Program
{
    static void Main(string[] args)
    {
        int a = 3;
        int b = 2137;
        int k1 = 0;
        int k2 = 0;

        int m = Euklides.NWD_Odejmowanie(a, b, ref k2);
        int n = Euklides.NWD_Dzielenie(a, b, ref k1);

        Console.WriteLine("Dzielenie: " + k1 + " krokow");
        Console.WriteLine("Odejmowanie: " + k2 + " krokow");
        Console.WriteLine("NWD: " + m);

        Console.ReadLine();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static double T(double n) //złozonosc czasowa tego algorytmu
        {
            return n * Math.Log(Math.Log(n, 2), 2);
        }

        static double Czas(int n, double sec, int m, int razy)
        {
            double result = (sec * (T(m) / T(n))) / razy; //wzor wynikajacy z rozumowania, ktore podalem w uzasadnieniu

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Czas(16, 15.0, 256, 2)); //wywowlanie funkcji
            Console.ReadLine();
        }

        
    }
}

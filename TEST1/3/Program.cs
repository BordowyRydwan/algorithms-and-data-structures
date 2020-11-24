using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        /*
        Podejscie zachlanne:
        
            Dla kazdego posilku policze jak bardzo jest oplacalny na osobe. Potem posegreguje je wedlug tej oplacalnosci na osobe (malejaco).
            Bede dobieral ten najbardziej oplacalny az do momentu, gdy nie bedzie sie dało - wtedy wezme ten mniej oplacalny, ale na mniej osob

        Zlozonosc: taka jak sortowania - u mnie jest O(n^2), bo użyłem sortowania bąbelkowego - da się zejsc do O(n log(n)), ale mam na kolokwium za mało czasu :). Złożonosc listy jest mniejsza niż O(n^2) i nie ma wpływu.
        */

        static List<int> Grupy(int k, int[] ceny, int[] wagi)
        {
            List<int> resultArr = new List<int>();
            double[] oplacalnosci = new double[wagi.Length];

            for(int i = 0; i < wagi.Length; ++i)
            {
                double oplacalnosc = ceny[i] / wagi[i];

                oplacalnosci[i] = oplacalnosc;
            }

            for (int i = 0; i < ceny.Length - 1; ++i) //sortuje wagi i ceny po oplacalnosci
            {
                for (int j = 0; j < ceny.Length - 1; ++j)
                {
                    double oplacalnoscNast = ceny[j + 1] / wagi[j + 1];
                    double oplacalnoscAktualnego = ceny[j] / wagi[j];

                    if (oplacalnoscAktualnego < oplacalnoscNast)
                    {

                        int tmpCena = ceny[j];
                        int tmpWart = wagi[j];

                        ceny[j] = ceny[j + 1];
                        ceny[j + 1] = tmpCena;

                        wagi[j] = wagi[j + 1];
                        wagi[j + 1] = tmpWart;
                    }

                }
            }

            for(int i = wagi.Length - 1; k > 0; --i) //zabieram posiłki z puli aż zapełnię brzuchy całej rodzinie
            {
                while(wagi[i] <= k) //dobieram najbardziej opłacalny na osobę posiłek do momentu aż będzie wymagał więcej osób niż jest w rodzinie
                {
                    k -= wagi[i];
                    resultArr.Add(wagi[i]);
                }
            }

            return resultArr;

        }

        static void Main(string[] args)
        {
            int[] ceny = { 5, 8, 9, 10, 7, 21 };
            int[] wagi = { 1, 2, 3, 4, 5, 6 };


            List<int> grupy = Grupy(9, ceny, wagi);
            List<int> grupy2 = Grupy(13, ceny, wagi);

            grupy.Reverse();
            grupy2.Reverse();

            foreach (int item in grupy)
            {
                Console.WriteLine(item);
            }

            foreach (int item in grupy2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}

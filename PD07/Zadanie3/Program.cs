using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {

        //true - czarny
        //false - bialy
        //
        //Nie wiedziałem o którą konkretnie implementację listy chodzi w poleceniu, to tym razem użyłem tej od Microsoftu
        //(w zad 1 użyłem dla odmiany listy dowiązaniowej)

        public static bool BialoCzarne(List<bool> S)
        {
            while(S.Count > 1)
            {
                bool item1 = S[0];
                bool item2 = S[1];

                S.RemoveRange(0, 2);

                if(item1 != item2)
                {
                    S.Insert(0, false);
                }
            }

            return S[0];
        }

        static void Main(string[] args)
        {
            List<bool> zbiorKul = new List<bool>() { true, false, false, true, true, false};
            bool wynik = BialoCzarne(zbiorKul);
            string str = wynik ? "czarny" : "bialy";

            Console.WriteLine("Kolor ostatniej kuli: " + str);
            Console.ReadLine();
        }
    }
}

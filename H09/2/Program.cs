using System;
using System.Collections.Generic;

class Węzeł
{
    public String wartość;
    public List<Węzeł> dzieci;
}

class Drzewo
{
    public Węzeł korzeń;
}

class Program
{
    static Węzeł UtwórzWęzeł(String wartość)
    {
        Węzeł węzeł = new Węzeł();
        węzeł.wartość = wartość;
        węzeł.dzieci = new List<Węzeł>();
        return węzeł;
    }

    static void DodajWęzeł(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.dzieci.Add(dziecko);
    }

    static void DołączDzieci(string drzewo, Węzeł węzeł)
    {

        if(drzewo.Length == 1)
        {
            return;
        }

        List<string> dzieci = new List<string>();
        List<int> leweNawiasy = new List<int>();
        List<int> praweNawiasy = new List<int>();

        int lewe = 0;
        int prawe = 0;

        for(int i = 0; i < drzewo.Length; ++i)
        {
            if (drzewo[i] == '(')
            {
                lewe++;
                leweNawiasy.Add(i);

                while (lewe != prawe)
                {
                    i++;

                    if (drzewo[i] == '(')
                    {
                        lewe++;
                    }

                    if (drzewo[i] == ')')
                    {
                        prawe++;
                    } 
                }

                praweNawiasy.Add(i);
            }

            lewe = 0;
            prawe = 0;
        }

        for(int i = 0; i < leweNawiasy.Count; ++i)
        {
            string dziecko = drzewo.Substring(leweNawiasy[i] + 1, praweNawiasy[i] - leweNawiasy[i] - 1);

            dzieci.Add(dziecko);
        }

        for(int i = 0; i < dzieci.Count; ++i)
        {
            string wartosc = dzieci[i][0].ToString();
            Węzeł węzełDziecka = UtwórzWęzeł(wartosc);

            DodajWęzeł(węzeł, węzełDziecka);

        }

        for(int i = 0; i < węzeł.dzieci.Count; ++i)
        {
            DołączDzieci(dzieci[i], węzeł.dzieci[i]);
        }
    }

    static void KonstruujDrzewo(Drzewo drzewo, Węzeł korzeń, string nawiasowe)
    {
        DołączDzieci(nawiasowe, korzeń);
        drzewo.korzeń = korzeń.dzieci[0];
    }

    static void Main(string[] args)
    {
        Drzewo drzewo = new Drzewo();
        Węzeł korzeń = UtwórzWęzeł("");
        string nawiasowe = "(A(B(F)(D(H))(J))(C(G)(E(K))))"; //przykład z wykładu

        KonstruujDrzewo(drzewo, korzeń, nawiasowe); //nasz algorytm

        //testowo przejde drzewo tylko w lewą stronę

        Węzeł test = drzewo.korzeń;

        while (true)
        {
            Console.WriteLine(test.wartość);

            if (test.dzieci.Count != 0)
            {
                test = test.dzieci[0];
            }
            else
            {
                break;
            }
        }

        //testowo przejde drzewo tylko w prawą stronę

        Console.WriteLine();
        test = drzewo.korzeń;

        while (true)
        {
            Console.WriteLine(test.wartość);

            if (test.dzieci.Count != 0)
            {
                test = test.dzieci[test.dzieci.Count - 1];
            }
            else
            {
                break;
            }
        }

        Console.ReadKey();

    }
}


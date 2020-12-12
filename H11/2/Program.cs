using System;
using System.Collections.Generic;

class Węzeł
{
    public int wartość;
    public Węzeł lewy;
    public Węzeł prawy;
}

// klasa Drzewo
class Drzewo
{
    public Węzeł korzeń;
}

class Program
{
    static Węzeł UtwórzWęzeł(int wartość)
    {
        Węzeł węzeł = new Węzeł();
        węzeł.wartość = wartość;

        węzeł.prawy = null;
        węzeł.lewy = null;

        return węzeł;
    }

    static void InicjujWęzeł(Węzeł węzeł, int wartość)
    {
        węzeł.wartość = wartość;
    }

    // in-order z wcięciami (odwrotnie)
    static void Wypisuj(Węzeł węzeł, int poziom)
    {

        string wcięcie = "";
        int p = poziom;
        while (p-- > 0) wcięcie += " ";
        if (węzeł == null) Console.WriteLine(wcięcie + "*");
        else
        {
            if (węzeł.lewy != null || węzeł.prawy != null)
                Wypisuj((Węzeł)węzeł.prawy, poziom + 3);
            Console.WriteLine(wcięcie + węzeł.wartość);
            if (węzeł.lewy != null || węzeł.prawy != null)
                Wypisuj((Węzeł)węzeł.lewy, poziom + 3);
        }
    }


    // iteracyjna
    static void Wstaw(Drzewo drzewo, Węzeł węzeł)
    {
        if (drzewo.korzeń == null) drzewo.korzeń = węzeł;
        else
        {
            Węzeł tmp = drzewo.korzeń;
            while (tmp != null)
            {
                if (tmp.wartość > węzeł.wartość)
                {
                    if (tmp.lewy != null) tmp = tmp.lewy;
                    else
                    {
                        tmp.lewy = węzeł;
                        return;
                    }
                }
                else
                {
                    if (tmp.prawy != null) tmp = tmp.prawy;
                    else
                    {
                        tmp.prawy = węzeł;
                        return;
                    }
                }
            }
        }
    }

    static void WstawRekurencyjnie(Drzewo drzewo, Węzeł węzeł)
    {
        if (drzewo.korzeń == null) drzewo.korzeń = węzeł;
        else
            WstawRekurencyjnie(drzewo.korzeń, węzeł);
    }

    static void WstawRekurencyjnie(Węzeł korzeń, Węzeł węzeł)
    {
        if (korzeń.wartość > węzeł.wartość)
        {
            if (korzeń.lewy == null) korzeń.lewy = węzeł;
            else WstawRekurencyjnie(korzeń.lewy, węzeł);
        }
        else
        {
            if (korzeń.prawy == null) korzeń.prawy = węzeł;
            else WstawRekurencyjnie(korzeń.prawy, węzeł);
        }
    }

    static int Max(Drzewo d)
    {
        Węzeł tmp = d.korzeń;
        while (tmp.prawy != null)
            tmp = tmp.prawy;
        return tmp.wartość;
    }

    static int Min(Drzewo d)
    {
        Węzeł tmp = d.korzeń;
        while (tmp.lewy != null)
            tmp = tmp.lewy;
        return tmp.wartość;
    }


    static int Poprzednik(Węzeł korzeń, Węzeł węzeł)
    {
        if(korzeń.wartość == węzeł.wartość)
        {
            Drzewo tmp = new Drzewo();
            tmp.korzeń = korzeń.lewy;

            return Max(tmp);
        }

        if(korzeń.wartość > węzeł.wartość)
        {
            return Poprzednik(korzeń.lewy, węzeł);
        }
        else
        {
            return Poprzednik(korzeń.prawy, węzeł);
        }
    }

    static int Następnik(Węzeł korzeń, Węzeł węzeł)
    {
        if (korzeń.wartość == węzeł.wartość)
        {
            Drzewo tmp = new Drzewo();
            tmp.korzeń = korzeń.prawy;

            return Min(tmp);
        }

        if (korzeń.wartość > węzeł.wartość)
        {
            return Następnik(korzeń.lewy, węzeł);
        }
        else
        {
            return Następnik(korzeń.prawy, węzeł);
        }
    }

    static void Main()
    {
        int[] tab = { 10, 16, 12, 7, 9, 2, 21, 6, 17, 1, 15 };

        Drzewo drzewoA = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            WstawRekurencyjnie(drzewoA, w);
        }

        Wypisuj(drzewoA.korzeń, 0);
        Console.WriteLine();

        Console.WriteLine("======================");
        Console.WriteLine("Poprzednik węzła 16: {0}", Poprzednik(drzewoA.korzeń, drzewoA.korzeń.prawy));
        Console.WriteLine("Następnik węzła 16: {0}", Następnik(drzewoA.korzeń, drzewoA.korzeń.prawy));

        Console.ReadKey();
    }
}




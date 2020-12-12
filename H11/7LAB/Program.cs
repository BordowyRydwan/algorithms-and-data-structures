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

    static void LewaRotacja(Węzeł węzeł)
    { 
        if (węzeł.prawy == null)
        {
            Console.WriteLine("Nie można zamienić: {0}", węzeł.wartość);
            return;
        }

        Drzewo poddrzewo = new Drzewo();
        Węzeł podkorzeń = UtwórzWęzeł(węzeł.wartość);

        poddrzewo.korzeń = podkorzeń;

        poddrzewo.korzeń.prawy = węzeł.prawy.lewy;
        poddrzewo.korzeń.lewy = węzeł.lewy;

        węzeł.wartość = węzeł.prawy.wartość;
        węzeł.lewy = poddrzewo.korzeń;
        węzeł.prawy = węzeł.prawy.prawy;
    }

    static void PrawaRotacja(Węzeł węzeł)
    {

        if (węzeł.lewy == null)
        {
            Console.WriteLine("Nie można zamienić: {0}", węzeł.wartość);
            return;
        }

        Drzewo poddrzewo = new Drzewo();
        Węzeł podkorzeń = UtwórzWęzeł(węzeł.wartość);

        poddrzewo.korzeń = podkorzeń;

        poddrzewo.korzeń.lewy = węzeł.lewy.prawy;
        poddrzewo.korzeń.prawy = węzeł.prawy;

        węzeł.wartość = węzeł.lewy.wartość;
        węzeł.prawy = poddrzewo.korzeń;
        węzeł.lewy = węzeł.lewy.lewy;
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

        //ZADANIE 7

        Console.WriteLine("-------- DRZEWO ---------");

        Wypisuj(drzewoA.korzeń, 0);

        Console.WriteLine("-------- po obrocie wezla 16 w prawo ---------");

        PrawaRotacja(drzewoA.korzeń.prawy);

        Wypisuj(drzewoA.korzeń, 0);
        Console.WriteLine();

        Console.WriteLine("-------- po obrocie wezla w lewo ---------");

        LewaRotacja(drzewoA.korzeń.prawy);

        Wypisuj(drzewoA.korzeń, 0);
        Console.WriteLine("==============");

        Console.ReadKey();
    }
}



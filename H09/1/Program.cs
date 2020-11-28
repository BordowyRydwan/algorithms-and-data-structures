using System;
using System.Collections.Generic;

class Węzeł
{
    public String wartość;
    public Węzeł lewy;
    public Węzeł prawy;
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
        return węzeł;
    }

    static void DodajLewy(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.lewy = dziecko;
    }
    static void DodajPrawy(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.prawy = dziecko;
    }

    static void SzukajRodzica(Węzeł węzeł, string wartosc, string rodzic)
    {
        if (węzeł == null)
        {
            return;
        }
        if(wartosc == węzeł.wartość)
        {
            Console.WriteLine(rodzic);
        }
        else
        {
            SzukajRodzica(węzeł.lewy, wartosc, węzeł.wartość);
            SzukajRodzica(węzeł.prawy, wartosc, węzeł.wartość);
        }    
    }

    static void Main(string[] args)
    {
        Drzewo drzewo = new Drzewo();

        drzewo.korzeń = UtwórzWęzeł("F");
        Węzeł wB = UtwórzWęzeł("B");
        Węzeł wA = UtwórzWęzeł("A");
        Węzeł wC = UtwórzWęzeł("C");
        Węzeł wD = UtwórzWęzeł("D");
        Węzeł wE = UtwórzWęzeł("E");
        Węzeł wG = UtwórzWęzeł("G");
        Węzeł wH = UtwórzWęzeł("H");
        Węzeł wI = UtwórzWęzeł("I");

        DodajLewy(wD, wC);
        DodajPrawy(wD, wE);
        DodajLewy(wB, wA);
        DodajPrawy(wB, wD);

        DodajLewy(wI, wH);
        DodajPrawy(wG, wI);

        DodajLewy(drzewo.korzeń, wB);
        DodajPrawy(drzewo.korzeń, wG);

        SzukajRodzica(drzewo.korzeń, "E", "");
        Console.ReadKey();

    }
}


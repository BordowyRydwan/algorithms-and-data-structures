using System;
using System.Collections;

class Zbiór
{
    public Hashtable elementy = new Hashtable();

    public void Dodaj(Object wartość)
    {
        elementy.Add(wartość.GetHashCode(), wartość);
    }

    public void Usuń(Object klucz)
    {
        if (elementy.ContainsKey(klucz))
        {
            elementy.Remove(klucz);
        }
    }

    public bool CzyZawiera(Object klucz)
    {
        return elementy.ContainsKey(klucz.GetHashCode());
    }

    public static Zbiór CzęśćWspólnaZbiorów(Zbiór z1, Zbiór z2)
    {
        Zbiór wynik = new Zbiór();

        foreach (DictionaryEntry item in z1.elementy)
        {
            if (z2.CzyZawiera(item.Key))
            {
                wynik.Dodaj(item.Value);
            }
        }

        return wynik;
    }

    public static Zbiór SumaZbiorów(Zbiór z1, Zbiór z2)
    {
        Zbiór wynik = new Zbiór();

        foreach (DictionaryEntry item in z1.elementy)
        {
            wynik.Dodaj(item.Value);
        }

        foreach (DictionaryEntry item in z2.elementy)
        {
            if (!wynik.CzyZawiera(item.Key))
            {
                wynik.Dodaj(item.Value);
            }
        }

        return wynik;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Zbiór set1 = new Zbiór();
        Zbiór set2 = new Zbiór();

        set1.Dodaj("1");
        set1.Dodaj("3");
        set1.Dodaj("4");
        set1.Dodaj("5");
        set1.Dodaj("7");

        set2.Dodaj("2");
        set2.Dodaj("3");
        set2.Dodaj("4");
        set2.Dodaj("5");
        set2.Dodaj("6");

        Zbiór częścWspolna = Zbiór.CzęśćWspólnaZbiorów(set1, set2);
        Zbiór suma = Zbiór.SumaZbiorów(set1, set2);

        Console.WriteLine("Czesc wspolna:");

        foreach (DictionaryEntry item in częścWspolna.elementy)
        {
            Console.WriteLine("wartosc: {0}", item.Value);
        }

        Console.WriteLine("Suma:");

        foreach (DictionaryEntry item in suma.elementy)
        {
            Console.WriteLine("wartosc: {0}", item.Value);
        }

        Console.ReadKey();
    }
}


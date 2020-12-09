using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    // Interfejs kopca

    static void Napraw(int[] kopiec, int węzeł)
    {
        int wielkość = kopiec.Length;
        int największy = węzeł;
        int lewe = 2 * węzeł + 1;
        int prawe = 2 * węzeł + 2;

        if (lewe < wielkość && kopiec[lewe] > kopiec[największy])
        {
            największy = lewe;
        }
        if (prawe < wielkość && kopiec[prawe] > kopiec[największy])
        {
            największy = prawe;
        }
        if (największy != węzeł)
        {
            int pomoc = kopiec[węzeł];

            kopiec[węzeł] = kopiec[największy];
            kopiec[największy] = pomoc;
            Napraw(kopiec, największy);
        }
    }

    static void UsunNajwieksza(ref int[] kopiec)
    {
        kopiec[0] = kopiec[kopiec.Length - 1];

        Array.Resize(ref kopiec, kopiec.Length - 1);

        Napraw(kopiec, 0);
    }

    static void Wstaw(ref int[] kopiec, int wezel)
    {
        Array.Resize(ref kopiec, kopiec.Length + 1);

        kopiec[kopiec.Length - 1] = wezel;

        for(int i = kopiec.Length - 1; i > 0;)
        {
            int rodzic = (int)Math.Floor(Convert.ToDecimal((i - 1) / 2));

            int tmp = kopiec[rodzic];

            if (tmp < kopiec[i])
            {
                kopiec[rodzic] = kopiec[i];
                kopiec[i] = tmp;
                i = rodzic;
            }
            else
            {
                break;
            }

        }


    }

    static void Buduj(int[] kopiec)
    {
        int wielkość = kopiec.Length;
        for (int i = (wielkość - 1) / 2; i >= 0; i--)
            Napraw(kopiec, i);
    }

    static int Wysokość(int[] kopiec)
    {
        int h = 0;
        for (int i = 1; i < kopiec.Length; i = 2 * i + 1)
        {
            h++;
        }
        return h;
    }

    static int IleLiści(int[] kopiec)
    {
        int ile = 0;
        for (int i = 0; i < kopiec.Length; i++)
        {
            // jak nie ma nawet lewego dziecka to liść
            if (2 * i + 1 >= kopiec.Length) ile++;
        }
        return ile;
    }

    static bool CzyKopiec(int[] kopiec)
    {
        bool b = true;
        for (int i = 0; b && i < kopiec.Length / 2; i++)
        {
            if (kopiec[2 * i + 1] > kopiec[i]) b = false;
            if (2 * i + 2 < kopiec.Length && kopiec[2 * i + 2] > kopiec[i]) b = false;
        }
        return b;
    }

    static void Main(string[] args)
    {
        int[] dane = {27, 13, 12, 5, 3, 17, 23, 44, 55, 66, 77 };
        int[] doWstawienia = { 1, 5, 2, 6, 4, 7, 11 };

        Buduj(dane);

        foreach(int i in doWstawienia)
        {
            Wstaw(ref dane, i);

            foreach (int num in dane)
            {
                Console.Write(num + " ");

            }

            Console.WriteLine();
        }

        for(int i = 0; i < 3; i++)
        {
            UsunNajwieksza(ref dane);

            foreach (int num in dane)
            {
                Console.Write(num + " ");

            }

            Console.WriteLine();
        }


        Console.ReadLine();
      
    }
}


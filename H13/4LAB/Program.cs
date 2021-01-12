using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static List<int> DFS(int[,] tab, int start) //metoda DFS ordynarnie ukradziona z kodu z laboratoriów 13 :)
    {
        Stack<int> stos = new Stack<int>();
        List<int> wyniki = new List<int>();
        bool[] odwiedzone = new bool[tab.GetLength(0)];

        stos.Push(start);
        while (stos.Count > 0)
        {
            int pobrany = stos.Pop();
            if (odwiedzone[pobrany] == false)
            {
                odwiedzone[pobrany] = true;
                wyniki.Add(pobrany);
                for (int i = tab.GetLength(1) - 1; i >= 0; i--)
                {
                    if (tab[pobrany, i] != 0)
                    {
                        stos.Push(i);
                    }
                }
            }
        }
        return wyniki;
    }

    //Technicznie rzecz biorąc, to spójność grafu sprawdza, czy da się przejść wszystkie wierzchołki.
    //Starczy więc sprawdzić, czy liczba odwiedzonych wierzchołków jest równa liczbie wszystkich wierzchołków.

    static bool CzySpojny(int[,] tab, int start = 0)
    {
        return tab.GetLength(0) == DFS(tab, start).Count;
    }

    static void Main(string[] args)
    {
        int[,] G = //graf spójny
        {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 1, 1, 0 },
            { 1, 1, 0, 0, 1 },
            { 0, 1, 0, 0, 1 },
            { 0, 0, 1, 1, 0 }
        };

        int[,] GN = //graf niespójny
        {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 1, 0, 0 },
            { 1, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 1, 0 }
        };

        Console.WriteLine(CzySpojny(G));
        Console.WriteLine(CzySpojny(GN));
        Console.Read();
    }
}


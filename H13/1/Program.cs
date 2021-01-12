using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static List<int> BFS(int[,] tab, int start)
    {
        Queue<int> kolejka = new Queue<int>(); //kolejka
        List<int> wyniki = new List<int>();
        bool[] odwiedzone = new bool[tab.GetLength(0)];
        kolejka.Enqueue(start);

        while (kolejka.Count > 0)
        {
            int pobrany = kolejka.Dequeue();
            if (odwiedzone[pobrany] == false)
            {
                odwiedzone[pobrany] = true;
                wyniki.Add(pobrany);
                for (int i = 0; i < tab.GetLength(1); i++)
                {
                    if (tab[pobrany, i] != 0)
                    {
                        kolejka.Enqueue(i);
                    }
                }
            }
        }
        return wyniki;
    }

    //Podobna historia jak w zadaniu 4 z laboratoriów - spójnosc jest gdy przejscie BFS odwiedzi tyle wierzchołków ile istnieje w grafie.

    static bool CzySpojny(int[,] tab, int start = 0)
    {
        return tab.GetLength(0) == BFS(tab, start).Count;
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


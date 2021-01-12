using System;
using System.Collections.Generic;

//Zaimplementuj algorytm Dijkstry zgodnie z pseudokodem podanym na wykładzie.
//    Dla grafów z zadania 2 wypisz krok po kroku realizację algorytmu Dijkstry, 
//    wybierając jako startowy wierzchołek pierwszy(w przypadku B ten z krawędzią 
//        cykliczną). 

class Krawedz
{
    public int wierzcholek;
    public int waga;

    public Krawedz(int wierzcholek, int waga)
    {
        this.wierzcholek = wierzcholek;
        this.waga = waga;
    }
}

class Program
{
    static int[] Dijkstra(List<List<Krawedz>> G, int s)
    {
        int n = G.Count;
        bool[] L = new bool[n]; // domyslnie false czyli w R
        int[] w = new int[n];
        int[] p = new int[n];

        for(int i = 0; i < L.Length; ++i)
        {
            p[i] = -1;
        }


        //Inicjacja 
        for (int i = 0; i < L.Length; i++)
            w[i] = int.MaxValue; // nieskończoność

        w[s] = 0;
        L[s] = true;
        for (int j = 0; j < G[s].Count; j++)
            if (L[G[s][j].wierzcholek] == false)
            {
                w[G[s][j].wierzcholek] = G[s][j].waga;
                p[G[s][j].wierzcholek] = s;
            }
                


        //właściwe obliczenia

        // za każdym razem dodajemy jeden wierzchołek a zostało ich n-1
        // dlatego petla po i chociaz i nie jest wewnatrz wykorzystywane
        for (int i = 1; i < n; i++)
        {
            // UWAGA
            // to poniżej jest liniowe bo nawet jak został jeden  
            // nierozważony wierzchołek to przeglądam całą tablicę
            // to co jest w L z wartością false trzeba by umieścić w minimalnym kopcu 
            // binarnym, wtedy od razu najbliższy wierzchołek byłby na szczycie kopca
            // naprawa kopca byłaby logarytmiczna
            // ale należy pamiętać, że podczas poprawiania odległości sąsiadów
            // klucze w kopcu się zmieniają (zmniejszają) czyli dodatkowo oprócz
            // naprawy byłoby heapup dla zmienionych kluczy
            // ale to też jest logarytmiczne a takich napraw jest nie więcej niż krawędzi


            //znajdź pierwszy nierozważony
            int u = 0;
            for (int j = 0; j < n; j++)
            {
                if (L[j] == false)
                {
                    u = j;
                    break;
                }
            }

            for (int j = 0; j < n; j++) //znajdź nierozważony najblizszy s
            {
                if (L[j] == false && w[j] < w[u])
                    u = j;
            }

            L[u] = true;

            // poprawianie odległości sąsiadów
            for (int j = 0; j < G[u].Count; j++)
            {
                if (L[G[u][j].wierzcholek] == false)
                {
                    if (w[u] + G[u][j].waga < w[G[u][j].wierzcholek])
                    {
                        w[G[u][j].wierzcholek] = w[u] + G[u][j].waga;
                        p[G[u][j].wierzcholek] = u;
                    }
                }
            }
        }

        //wypisanie ścieżek
        for(int i = 0; i < n; ++i)
        {
            int k = i;

            while(k >= 0)
            {
                Console.Write(k + " ");
                k = p[k];
            }

            Console.WriteLine();
        }

        return w;
    }

    static void Main(string[] args)
    {
        List<List<Krawedz>> G = new List<List<Krawedz>>();
        // przyklad B
        int[,] tab =
        {
            { 1, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 2, 0, 4, 0, 1 },
            { 0, 2, 0, 4, 1, 2, 3 },
            { 3, 0, 4, 0, 5, 3, 3 },
            { 0, 4, 1, 5, 0, 1, 2 },
            { 0, 0, 2, 3, 1, 0, 2 },
            { 7, 1, 3, 3, 2, 2, 0 }
        };

        // NUMERACJA OD ZERA
        for (int i = 0; i < tab.GetLength(0); i++)
        {
            List<Krawedz> lista = new List<Krawedz>();
            for (int j = 0; j < tab.GetLength(1); j++)
            {
                if (tab[i, j] > 0)
                {
                    lista.Add(new Krawedz(j, tab[i, j]));
                }
            }
            G.Add(lista);
        }

        int s = 0;
        int[] w = Dijkstra(G, s);

        for (int i = 0; i < w.Length; i++)
            Console.WriteLine("od {0} do {1} min długość ścieżki {2}", s, i, w[i]);
        Console.WriteLine();

        Console.ReadKey();
    }
}


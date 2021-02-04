using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    //METODY POMOCNICZE
    class UndirectedGraph
    {
        Dictionary<int, List<(int Value, int Weight)>> elements = new Dictionary<int, List<(int Value, int Weight)>>();

        public UndirectedGraph() { }

        public UndirectedGraph(int element)
        {
            AddVertice(element);
        }

        public UndirectedGraph(int[,] neighborhoodMatrix)
        {

            for (int i = 0; i < neighborhoodMatrix.GetLength(0); ++i)
            {
                AddVertice(i);

                for (int j = 0; j < neighborhoodMatrix.GetLength(1); ++j)
                {
                    if (neighborhoodMatrix[i, j] != 0)
                    {
                        AddEdge(i, j, neighborhoodMatrix[i, j]);
                    }
                }
            }
        }

        public void AddEdge(int from, int to, int weight)
        {
            if (!elements.ContainsKey(from))
            {
                AddVertice(from);
            }

            elements[from].Add((to, weight));
        }

        public void AddVertice(int element)
        {
            var newEdgeList = new List<(int Value, int Weight)>();

            elements.Add(element, newEdgeList);
        }

        public int[] Dijkstra(int start, int[] penalties)
        {
            bool[] visited = new bool[elements.Count];
            int[] weights = new int[elements.Count];

            for (int i = 0; i < weights.Length; ++i)
            {
                weights[i] = int.MaxValue;
            }

            weights[start] = penalties[start];
            visited[start] = true;

            //nadanie wag tras ze startu do sąsiedniego wierzchołka
            foreach (var item in elements[start])
            {
                if (visited[item.Value] == false)
                {
                    weights[item.Value] = item.Weight;
                }
            }

            for (int i = 1; i < elements.Count; ++i)
            {
                int lowestNotVisited = 0;

                //szukanie jakiegokolwiek nieodwiedzonego wierzchołka
                while (visited[lowestNotVisited] != false)
                {
                    lowestNotVisited++;
                }

                //wybranie nieodwiedzonego wierzchołka o najmniejszej wadze
                for (int j = 0; j < elements.Count; ++j)
                {
                    if (visited[j] == false && weights[j] < weights[lowestNotVisited])
                    {
                        lowestNotVisited = j;
                    }
                }

                //odwiedzamy wierzcholek o najmniejszej wadze
                visited[lowestNotVisited] = true;

                //uzupelniamy na liscie wagi tras do sasiednich wierzchołków
                foreach (var item in elements[lowestNotVisited])
                {
                    if (visited[item.Value] == false)
                    {
                        weights[item.Value] = Math.Min(weights[lowestNotVisited] + item.Weight, weights[item.Value]);
                    }
                }
            }

            return weights;
        }

        

        public override string ToString()
        {
            string str = "";

            foreach (var vertice in elements)
            {
                str += "L(" + vertice.Key + ") = {";

                foreach (var listItem in vertice.Value)
                {
                    str += "{" + listItem.Value + ", " + listItem.Weight + "}, ";
                }

                str += "}\n";
            }

            return str;
        }
    }

    static void LiczOdleglosci(int nrMiasta1, int nrMiasta2, int[] kary, UndirectedGraph trasa)
    {
        (int[], int) trasyZ1 = (trasa.Dijkstra(1, kary), 1);
        (int[], int) trasyZ3 = (trasa.Dijkstra(3, kary), 3);

        for (int i = 0; i < kary.GetLength(0); ++i)
        {
            int min = Math.Min(trasyZ1.Item1[i], trasyZ3.Item1[i]);
            int minIndex = Math.Min(trasyZ1.Item1[i], trasyZ3.Item1[i]) == trasyZ1.Item1[i] ? trasyZ1.Item2 : trasyZ3.Item2;
            Console.WriteLine("Do miasta {0} czas {1} z punktu {2}", i + 1, min, minIndex);
        }
    }

    static void Main(string[] args)
    {
        /*
         Wyjaśnienie algorytmu (jeśli dobrze zrozumiałem wyjasnienia Pana Doktora):

        Chcemy uzyskać porównanie - z którego miasta z dwóch wybranych dojedziemy szybciej w miejsce wybrane w grafie.
        Jest to modyfikacja zagadnienia algorytmu Dijkstry (który zwraca zazwyczaj tablicę najmniejszych odległości z wybranego wierzchołka do wszystkich
        innych), tylko, że dodajemy do czasu na samym początku "kary" związane z czasem zbierania się i bierzemy również i to pod rozwagę.
        Tak samo jak algorytm Dijkstry, ma to złożoność O(V^2)

        Nie do końca zrozumiałem postać danych testowych z zadania, więc graf jest skopiowany razem z wierzchołkami statrowymi, a kary na starcie są inne
        */

        int[,] trasy = {
            { 0, 6, 4, 3, 0, 0, 0, 0, },
            { 6, 0, 9, 0, 0, 8, 0, 0, },
            { 4, 9, 0, 8, 0, 0, 3, 0, },
            { 3, 0, 8, 0, 8, 0, 3, 0, },
            { 0, 0, 0, 8, 0, 0, 0, 0, },
            { 0, 8, 0, 0, 0, 0, 5, 0, },
            { 0, 0, 3, 0, 0, 5, 0, 5, },
            { 0, 0, 0, 5, 0, 0, 5, 0, },
        };

        UndirectedGraph grafTras = new UndirectedGraph(trasy);
        int[] kary = { 1, 2, 3, 4, 5, 6, 7, 8};

        int miasto1 = 1;
        int miasto2 = 3;

        LiczOdleglosci(miasto1, miasto2, kary, grafTras);

        //KONIEC KODU
        Console.ReadLine();
    }
}


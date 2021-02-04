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

        public int[,] NeighbourhoodMatrix
        {
            get
            {
                int length = elements.Keys.Max();

                int[,] matrix = new int[length + 1, length + 1];

                foreach (var pair in elements)
                {
                    foreach (var (Value, Weight) in pair.Value)
                    {
                        matrix[pair.Key, Value] = Weight;
                    }
                }

                return matrix;
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

        public List<int> BFSTraversal(int start)
        {
            Queue<int> tmpQueue = new Queue<int>();
            List<int> result = new List<int>();
            bool[] visited = new bool[elements.Keys.Count];

            tmpQueue.Enqueue(start);

            while (tmpQueue.Count > 0)
            {
                int actualItem = tmpQueue.Dequeue();

                if (visited[actualItem] == false)
                {
                    visited[actualItem] = true;
                    result.Add(actualItem);

                    foreach (var vertice in elements[actualItem])
                    {
                        tmpQueue.Enqueue(vertice.Value);
                    }
                }
            }

            return result;
        }

        public List<int> DFSTraversal(int start)
        {
            Stack<int> tmpQueue = new Stack<int>();
            List<int> result = new List<int>();
            bool[] visited = new bool[elements.Keys.Count];

            tmpQueue.Push(start);

            while (tmpQueue.Count > 0)
            {
                int actualItem = tmpQueue.Pop();

                if (visited[actualItem] == false)
                {
                    visited[actualItem] = true;
                    result.Add(actualItem);

                    List<(int Value, int Weight)> verticeList = elements[actualItem];
                    verticeList.Reverse();

                    foreach (var vertice in verticeList)
                    {
                        tmpQueue.Push(vertice.Value);
                    }
                }
            }

            return result;
        }

        public bool IsConnected()
        {
            return BFSTraversal(elements.Keys.FirstOrDefault()).Count == elements.Count;
        }

        public int[] Dijkstra(int start)
        {
            bool[] visited = new bool[elements.Count];
            int[] weights = new int[elements.Count];

            for (int i = 0; i < weights.Length; ++i)
            {
                weights[i] = int.MaxValue;
            }

            weights[start] = 0;
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

    static void Main(string[] args)
    {
        int[,] trasy = {
            { 0, 1, 1, 0, 0, 0},
            { 1, 0, 0, 1, 0, 0},
            { 1, 0, 0, 1, 1, 0},
            { 0, 1, 1, 0, 1, 1},
            { 0, 0, 1, 1, 0, 0},
            { 0, 0, 0, 1, 0, 0},
        };

        UndirectedGraph grafTras = new UndirectedGraph(trasy);
        int[] trasyZWierzch1 = grafTras.Dijkstra(0);


        for (int i = 0; i < trasyZWierzch1.Length; ++i)
        {
            Console.WriteLine("{0} koszt {1}", i, trasyZWierzch1[i]);
        }

        //złożoność - taka jak dla Algorytmu Dijkstry, czyli O(V^2), gdzie V - liczba wierzchołków;

        //KONIEC KODU
        Console.ReadLine();
    }
}


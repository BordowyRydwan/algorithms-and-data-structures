using System;

class Node
{
    public Node Parent { get; set; }
    public Cell Data { get; set; }
    public int Rank { get; set; }
}

class Set
{
    //źródło dla struktury FindUnion: https://pl.wikipedia.org/wiki/Struktura_zbior%C3%B3w_roz%C5%82%C4%85cznych

    public void MakeSet(Node node)
    {
        node.Parent = null;
        node.Rank = 0;
    }

    public Node Find(Node node)
    {
        if(node.Parent == null)
        {
            return node;
        }

        node.Parent = Find(node.Parent);

        return node.Parent;
    }

    public void Union(Node node1, Node node2)
    {
        Node root1 = Find(node1);
        Node root2 = Find(node2);

        if (root1.Rank > root2.Rank)
        {
            root2.Parent = root1;
        }
        else if(root1.Rank < root2.Rank)
        {
            root1.Parent = root2;
        }
        else if (root1 != root2)
        {
            root2.Parent = root1;
            root1.Rank++;
        }
    }
}

class Cell
{
    public bool Right { get; set; } = true;
    public bool Down { get; set; } = true;
}

class Maze
{
    public Cell[,] CellSet { get; set; }
    public int Rows { get; }
    public int Cols { get; }

    public Maze(int width, int height)
    {
        CellSet = new Cell[height, width];

        Rows = height;
        Cols = width;

        for (int y = 0; y < Rows; ++y)
        {
            for(int x = 0; x < Cols; ++x)
            {
                CellSet[y, x] = new Cell();
            }
        }
    }

    public override string ToString()
    {
        string lines = "";

        for(int x = 0; x < Cols; ++x)
        {
            lines += " _";
        }

        lines += "\n";

        for (int y = 0; y < Rows; ++y)
        {
            lines += y == 0 ? " " : "|";

            for (int x = 0; x < Cols; ++x)
            {
                Cell cell = CellSet[y, x];

                if(cell.Down && cell.Right)
                {
                    if(y == Rows - 1 && x == Cols - 1)
                    {
                        lines += "_ ";
                    }

                    else
                    {
                        lines += "_|";
                    }
                }

                else if (cell.Down)
                {
                    lines += " _";
                }

                else if (cell.Right)
                {
                    lines += " |";
                }
            }

            lines += "\n";
        }

        return lines;
    }
}

class Program
{
    static void Main(string[] args)
    {
        const int ROWS = 10;
        const int COLS = 25;

        Maze maze = new Maze(COLS, ROWS);
        int cellsAmount = ROWS * COLS;
        Node[] nodeArray = new Node[cellsAmount];
        Set set = new Set();

        //inicjalizacja zbiorów rozłącznych
        for (int y = 0; y < maze.Rows; ++y)
        {
            for (int x = 0; x < maze.Cols; ++x)
            {
                int counter = y * maze.Cols + x;

                Node cellNode = new Node
                {
                    Data = maze.CellSet[y, x]
                };

                nodeArray[counter] = cellNode;
                set.MakeSet(cellNode);
            }
        }

        Random random = new Random();

        //dla każdej komórki losuję, którą ściankę usunąć - jak sąsiednie komórki są już połączone, to nic nie robię
        for (int y = 0; y < maze.Rows; ++y)
        {
            for (int x = 0; x < maze.Cols; ++x)
            {
                bool isRight = random.Next(0, 2) == 1 ? true : false;

                Node node1 = null;
                Node node2 = null;

                if (isRight)
                {
                    if (x == maze.Cols - 1)
                    {
                        continue;
                    }

                    for (int i = 0; i < cellsAmount; i++)
                    {
                        if (nodeArray[i].Data == maze.CellSet[y, x])
                        {
                            node1 = nodeArray[i];
                        }

                        if (nodeArray[i].Data == maze.CellSet[y, x + 1])
                        {
                            node2 = nodeArray[i];
                        }
                    }

                    Node node1Find = set.Find(node1);
                    Node node2Find = set.Find(node2);

                    if (node1Find != node2Find)
                    {
                        maze.CellSet[y, x].Right = false;
                        set.Union(node1, node2);
                    }
                }

                else
                {
                    if (y == maze.Rows - 1)
                    {
                        continue;
                    }

                    for (int i = 0; i < cellsAmount; i++)
                    {
                        if (nodeArray[i].Data == maze.CellSet[y, x])
                        {
                            node1 = nodeArray[i];
                        }

                        if (nodeArray[i].Data == maze.CellSet[y + 1, x])
                        {
                            node2 = nodeArray[i];
                        }
                    }

                    Node node1Find = set.Find(node1);
                    Node node2Find = set.Find(node2);

                    if (node1Find != node2Find)
                    {
                        maze.CellSet[y, x].Down = false;
                        set.Union(node1, node2);
                    }
                }
            }
        }

        //wymuszenie, żeby do ostatniej komórki prowadziło jakieś przejście
        if (!(maze.CellSet[ROWS - 1, COLS - 2].Right ^ maze.CellSet[ROWS - 2, COLS - 1].Down)){

            bool rand = random.Next(0, 2) == 1 ? true : false;

            if (rand)
            {
                maze.CellSet[ROWS - 1, COLS - 2].Right = false;
                maze.CellSet[ROWS - 2, COLS - 1].Down = true;
            }

            else
            {
                maze.CellSet[ROWS - 2, COLS - 1].Down = false;
                maze.CellSet[ROWS - 1, COLS - 2].Right = true;
            }
        }


        Console.WriteLine("Labirynt o W:{0} H:{1}", COLS, ROWS);
        Console.WriteLine(maze);

        Console.ReadLine();
    }
}


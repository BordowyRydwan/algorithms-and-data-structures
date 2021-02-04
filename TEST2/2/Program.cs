using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Jak zapewne widać po folderach projektu, odrzuciłem zadanie nr 1
 * */

class Program
{
    //KLASY POMOCNICZE
    public class BinaryNode<T>
    {
        public T Value { get; set; }

        BinaryNode<T> left = null;
        BinaryNode<T> right = null;

        public BinaryNode<T> Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public BinaryNode<T> Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public BinaryNode(T value)
        {
            this.Value = value;
            this.left = null;
            this.right = null;
        }

        public static BinaryNode<T> FindNode(T searchedValue, BinaryNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (Equals(searchedValue, node.Value))
            {
                return node;
            }

            BinaryNode<T> res1 = FindNode(searchedValue, node.Left);

            if (res1 != null)
            {
                return res1;
            }

            BinaryNode<T> res2 = FindNode(searchedValue, node.Right);

            if (res2 != null)
            {
                return res2;
            }

            return null;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }

    class BinaryTree<T>
    {
        public BinaryNode<T> Root { get; set; }

        public BinaryTree(T value)
        {
            this.Root = new BinaryNode<T>(value);
        }

        public BinaryTree(BinaryNode<T> node)
        {
            this.Root = node;
        }


        /*HELPER METHODS*/

        public BinaryNode<T> GetNodeByPath(bool[] path)
        {
            BinaryNode<T> tmpNode = Root;

            for (int i = 0; i < path.Length; ++i)
            {
                tmpNode = path[i] ? tmpNode.Right : tmpNode.Left;
            }

            return tmpNode;
        }

        public BinaryNode<T> FindNode(T value)
        {
            return BinaryNode<T>.FindNode(value, Root);
        }
    }

    class BST<T> : BinaryTree<T> where T : IComparable<T>
    {
        public BST(T value) : base(value) { }
        public BST(BinaryNode<T> value) : base(value) { }

        public void Insert(BinaryNode<T> node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                BinaryNode<T> tmpNode = Root;

                while (tmpNode != null)
                {
                    if (tmpNode.Value.CompareTo(node.Value) >= 0)
                    {
                        if (tmpNode.Left != null)
                        {
                            tmpNode = tmpNode.Left;
                        }
                        else
                        {
                            tmpNode.Left = node;
                            return;
                        }
                    }
                    else
                    {
                        if (tmpNode.Right != null)
                        {
                            tmpNode = tmpNode.Right;
                        }
                        else
                        {
                            tmpNode.Right = node;
                            return;
                        }
                    }
                }
            }
        }

        public void Insert(T value) => Insert(new BinaryNode<T>(value));

        public bool[] GetPathTo(T value)
        {
            BinaryNode<T> tmpNode = Root;
            List<bool> path = new List<bool>();

            while (value.CompareTo(tmpNode.Value) != 0)
            {
                if (tmpNode == null)
                {
                    return new bool[0];
                }

                if (value.CompareTo(tmpNode.Value) == 1)
                {
                    path.Add(true);
                    tmpNode = tmpNode.Right;
                    continue;
                }

                if (value.CompareTo(tmpNode.Value) == -1)
                {
                    path.Add(false);
                    tmpNode = tmpNode.Left;
                    continue;
                }
            }

            return path.ToArray();
        }

        public BinaryNode<T> NearestCommonNode(T element1, T element2)
        {
            if(FindNode(element1) == null || FindNode(element2) == null)
            {
                return null;
            }

            bool[] pathTo1 = GetPathTo(element1);
            bool[] pathTo2 = GetPathTo(element2);

            int pathLength = Math.Min(pathTo1.Length, pathTo2.Length);

            List<bool> pathToCommonNode = new List<bool>();

            for(int i = 0; i < pathLength; ++i)
            {
                if(pathTo1[i] == pathTo2[i])
                {
                    pathToCommonNode.Add(pathTo1[i]);
                }
                else
                {
                    break;
                }
            }

            bool[] pathArr = pathToCommonNode.ToArray();

            return GetNodeByPath(pathArr);
        }
    }

    static void Main(string[] args)
    {
        //Wyjasnienie dzialania
        /*
         * Zapisuje droge do pierwszego z wezlow a potem do drugiego z wezlow za pomoca tablic bool[]. Jesli te wezly maja wspolny wezel, to droga
         * dostepu do nich jest taka sama do momentu az algorytm napotka ten wspolny wezel. Z tego powodu porownuje tablice reprezentujace
         * drogi dostepu do wezlow - jesli w pewnym momencie sie roznia, to mamy sygnal, ze w wezle poprzednim do tej sytuacji mamy wspolny wezel
         * 
         * Zlozonosc: 
         * korzystam wylacznie z metody szukania elementu w drzewie binarnym, ktora jest pesymistycznie O(n). Porownywanie drog ma porownywalna, badzmniejsza zlozonosc, wiec CAŁOŚĆ JEST O(n)
        */


        BST<int> drzewo = new BST<int>(3);

        drzewo.Insert(2);
        drzewo.Insert(1);
        drzewo.Insert(6);
        drzewo.Insert(7);
        drzewo.Insert(5);

        /*
                        3
                    2           6
                1            5       7
                    
         
        */

        BinaryNode<int> wspolny = drzewo.NearestCommonNode(1, 5);
        Console.WriteLine("Wspolny: {0}", wspolny.Value);

        //KONIEC KODU
        Console.ReadLine();
    }
}
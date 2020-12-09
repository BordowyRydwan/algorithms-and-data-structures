using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class KolejkaPrioreytetowaMin
    {
        List<int> elements = new List<int>();
        int size = 0;

        public KolejkaPrioreytetowaMin(List<int> elements)
        {
            this.size = elements.Count;
            this.elements = elements;

            for (int i = (size - 1) / 2; i >= 0; i--)
            {
                Heapify(this.elements, i);
            }  
        }

        void Heapify(List<int> toHeapify, int node)
        {
            int length = elements.Count;
            int lowest = node;
            int left = 2 * node + 1;
            int right = 2 * node + 2;

            if (left < length && toHeapify[left] < toHeapify[lowest])
            {
                lowest = left;
            }
            if (right < length && toHeapify[right] < toHeapify[lowest])
            {
                lowest = right;
            }
            if (lowest != node)
            {
                int tmp = toHeapify[node];

                toHeapify[node] = toHeapify[lowest];
                toHeapify[lowest] = tmp;
                Heapify(toHeapify, lowest);
            }
        }

        public void Wstaw(int value)
        {
            elements.Add(value);

            for (int i = elements.Count - 1; i > 0;)
            {
                int rodzic = (int)Math.Floor(Convert.ToDecimal((i - 1) / 2));

                int tmp = elements[rodzic];

                if (tmp >= elements[i])
                {
                    elements[rodzic] = elements[i];
                    elements[i] = tmp;
                    i = rodzic;
                }
                else
                {
                    break;
                }

            }
        }

        public int Usun()
        {
            int minElement = elements[0];

            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(0);

            Heapify(elements, 0);
            
            return minElement;
        }

        public override string ToString() //do testów
        {
            string result = "";

            foreach(int elem in elements)
            {
                result += elem + " ";
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KolejkaPrioreytetowaMin queue = new KolejkaPrioreytetowaMin(new List<int>() { 5, 2, 1, 3, 6, 8, 4 });

            queue.Wstaw(9);
            queue.Usun();

            Console.WriteLine(queue);

            Console.ReadLine();
        }
    }
}

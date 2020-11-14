using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void QueueSort(Queue<int> queue)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            stack1.Push(queue.Dequeue());

            while (queue.Count > 0)
            {
                int num = queue.Dequeue();
                int max = stack1.Peek();

                if (num >= max)
                {
                    stack1.Push(num);
                    max = num;
                }
                else
                {
                    while (stack1.Count > 0)
                    {
                        int tmp = stack1.Peek();

                        if (tmp > num)
                        {
                            stack2.Push(stack1.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    stack1.Push(num);

                    while (stack2.Count > 0)
                    {
                        stack1.Push(stack2.Pop());
                    }
                }
            }


            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }

            while (stack2.Count > 0)
            {
                queue.Enqueue(stack2.Pop());
            }
        }

        static void Main(string[] args)
        {
            List<Queue<int>> queues = new List<Queue<int>>()
            {
                new Queue<int>(new int[] { 2, 1, 3, 7 }),
                new Queue<int>(new int[] { 1, 2, 1, 3, 5, 6 }),
                new Queue<int>(new int[] { 9, 2, 6, 4, 3, 7 }),
        };

            foreach (Queue<int> queue in queues)
            {
                QueueSort(queue);
            }

            foreach (Queue<int> queue in queues)
            {
                foreach (int num in queue)
                {
                    Console.Write(num + ", ");
                }

                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}

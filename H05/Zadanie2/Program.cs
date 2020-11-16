using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Point : IComparable<Point>
    {
        int x;
        int y;
        int z;

        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int CompareTo(Point point2)
        {
            if (point2 == null)
            {
                return -1;
            }

            if (this.x < point2.x)
            {
                return -1;
            }

            if (this.x > point2.x)
            {
                return 1;
            }

            if (this.y < point2.y)
            {
                return -1;
            }

            if (this.y > point2.y)
            {
                return 1;
            }

            if (this.z < point2.z)
            {
                return -1;
            }

            if (this.z > point2.z)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return "x:" + x + ", y:" + y + ", z:" + z;
        }

        public static bool operator> (Point a, Point b)
        {
            if(a.CompareTo(b) == 1)
            {
                return true;
            }

            return false;
        }

        public static bool operator< (Point a, Point b)
        {
            return b > a;
        }
    }

    class Program
    {
        static int Partition(Point[] arr, int left, int right, Point pivot)
        {
            while(left <= right)
            {
                while(arr[left] < pivot)
                {
                    left++;
                }

                while(arr[right] > pivot)
                {
                    right--;
                }

                if(left <= right)
                {
                    Point tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;

                    left++;
                    right--;
                }
            }

            return left;
        }

        static void QuickSort(Point[] arr, int left, int right)
        {
            if(left >= right)
            {
                return;
            }

            Point pivot = arr[(left + right) / 2];
            int partition = Partition(arr, left, right, pivot);

            QuickSort(arr, left, partition - 1);
            QuickSort(arr, partition, right);
        }

        static void Main(string[] args)
        {
            Point[] arrOfPoints =
            {
                new Point(0,0,0),
                new Point(0,1,1),
                new Point(2,0,1),
                new Point(5,2,4),
                new Point(2,1,5),
                new Point(3,4,1),
                new Point(0,0,7),
                new Point(9,1,1),
                new Point(1,1,1),
            };

            QuickSort(arrOfPoints, 0, arrOfPoints.Length - 1);

            foreach(Point point in arrOfPoints)
            {
                Console.WriteLine(point);
            }

            Console.Read();
        }
    }
}

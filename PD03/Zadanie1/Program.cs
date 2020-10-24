using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static int PowerNaive(int num, int power)
        {
            //Zlozonosc czasowa: O(n)
            int result = 1;

            for(int i = 0; i < power; ++i)
            {
                result *= num;
            }

            return result;
        }

        static int PowerRecursive(int num, int power)
        {
            //Zlozonosc: O(log(n))

            if(power == 1)
            {
                return num;
            }
            else if (Convert.ToBoolean(power % 2))
            {
                return num * PowerRecursive(num, (power - 1) / 2) * PowerRecursive(num, (power - 1) / 2);
            }
            else
            {
                return PowerRecursive(num, power / 2) * PowerRecursive(num, power / 2);
            }
        }

        static int PowerDynamic(int num, int power)
        {
            //Zlozonosc: O(log(n))

            int result = 1;

            while(power > 0)
            {
                if(Convert.ToBoolean(power % 2))
                {
                    result *= num;
                }

                num *= num;
                power /= 2;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PowerNaive(2, 4));
            Console.WriteLine(PowerRecursive(3, 5));
            Console.WriteLine(PowerDynamic(2, 4));

            Console.ReadKey();
        }
    }
}

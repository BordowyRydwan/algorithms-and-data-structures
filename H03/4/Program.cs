using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Program
    {
        static int HowManyChangeWays(int[] coins, int change)
        {
            int[] ways = new int[change + 1];

            ways[0] = 1;

            for (int i = 0; i < coins.Length; ++i)
            {
                for(int j = coins[i]; j < ways.Length; ++j)
                {
                    ways[j] += ways[j - coins[i]];
                }
            }

            return ways[ways.Length - 1];  
        }

        static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5 };

            for(int i = 1; i < 20; ++i)
            {
                Console.WriteLine(i + ") " + HowManyChangeWays(coins, i));
            }

            Console.Read();
        }
    }
}

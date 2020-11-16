using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SieveAlgorithm {
    public static List<int> FindPrimesLowerThanN(int n)
    {
        bool[] sieve = new bool[n + 1];
        List<int> primes = new List<int>();

        for(int i = 2; i < sieve.Length; ++i)
        {
            sieve[i] = true;
        }

        for(int i = 2; i*i < n; ++i)
        {
            if (sieve[i])
            {
                for (int j = i*i; j < n; j += i)
                {
                    sieve[j] = false;
                }
            }
        }

        for(int i = 2; i < sieve.Length; ++i)
        {
            if (sieve[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    } 
}

class Program
{
    static void Main(string[] args)
    {
        List<int> primesLowerThan2137 = SieveAlgorithm.FindPrimesLowerThanN(2137);

        long time = 0;
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        foreach(int number in primesLowerThan2137)
        {
            Console.WriteLine(number);
        }

        stopwatch.Stop();

        time = stopwatch.ElapsedTicks;

        Console.WriteLine("Tickow: " + time);

        Console.Read();

    }
}


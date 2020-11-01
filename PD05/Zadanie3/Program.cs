using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {

        static int GetMax(string[] arr)
        {
            int n = arr.Length;

            int max = arr[0].Length;
            for (int i = 1; i < n; i++)
            {
                if (arr[i].Length > max)
                    max = arr[i].Length;
            }

            return max;
        }

        static void CountSort(string[] arr, int digit)
        {
            const int MAX_ASCII = 128;

            string[] output = new string[arr.Length];
            int[] counters = new int[MAX_ASCII]; //tablica chowajaca alfabet
           
            for(int i = 0; i < MAX_ASCII; ++i)
            {
                counters[i] = 0;
            }

            for(int i = 0; i < arr.Length; ++i)
            {
                counters[digit < arr[i].Length ? arr[i][digit] + 1 : 0]++;
            }

            for(int i = 1; i < MAX_ASCII; ++i)
            {
                counters[i] += counters[i - 1];
            }

            for(int i = arr.Length - 1; i >= 0; --i)
            {
                output[counters[digit < arr[i].Length ? arr[i][digit] + 1 : 0] - 1] = arr[i];
                counters[digit < arr[i].Length ? arr[i][digit] + 1 : 0]--;
            }

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = output[i];
            }
        }

        static void RadixSort(string[] arr)
        {
            int longestWord = GetMax(arr);

            for(int i = longestWord; i > 0; --i)
            {
                CountSort(arr, i - 1);
            }
        }

        static void Main(string[] args)
        {

            string[] wordsArr =
            {
                "XAXAX",
                "AXXXA",
                "JSKLC",
                "KJHJKHKJN",
                "KNKJLMPOIK",
                "OIPKLOJ",
                "IOJIOMO",
                "MOIJMOP",
            };

            RadixSort(wordsArr);
        
            foreach (string word in wordsArr)
            {
                Console.WriteLine(word);
            }

            Console.Read();
        }
    }
}

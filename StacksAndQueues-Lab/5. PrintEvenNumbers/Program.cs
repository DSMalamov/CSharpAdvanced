using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var item in input)
            {
                if (item % 2 == 0)
                {
                    queue.Enqueue(item);
                }
                
            }

            Console.Write(string.Join(", ", queue));

        }
    }
}

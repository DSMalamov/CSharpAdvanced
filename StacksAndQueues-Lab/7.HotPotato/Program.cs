using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');
            int n = int.Parse(Console.ReadLine());
            int tosses = 1;

            Queue<string> queue = new Queue<string>(input);

            while (queue.Count != 1)
            {
                string currChild = queue.Dequeue();
                if (tosses < n)
                {
                    queue.Enqueue(currChild);
                    tosses++;
                }
                else
                {
                    Console.WriteLine($"Removed {currChild}");
                    tosses = 1;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}

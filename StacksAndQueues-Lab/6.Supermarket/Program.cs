using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Queue<string> queue = new Queue<string>();
            int counter = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    counter = 0;
                }
                else
                {
                    queue.Enqueue(command);
                    counter++;

                }
            }

            Console.WriteLine($"{counter} people remaining.");
        }
    }
}

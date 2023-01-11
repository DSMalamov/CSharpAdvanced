using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string command;
            int counter = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    if (n > queue.Count)
                    {
                        n = queue.Count;
                    }

                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}

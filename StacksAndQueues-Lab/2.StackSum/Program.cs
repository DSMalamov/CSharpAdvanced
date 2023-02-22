using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(input);

            string command;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArg = command
                    .Split(" ");

                if (cmdArg[0] == "add")
                {
                    int n1 = int.Parse(cmdArg[1]);
                    int n2 = int.Parse(cmdArg[2]);

                    numbers.Push(n1);
                    numbers.Push(n2);
                }
                else if (cmdArg[0] == "remove")
                {
                    int n = int.Parse(cmdArg[1]);

                    if (numbers.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            numbers.Pop();
                        }
                    }
                       
                }
            }
            int sum = 0;

            while (numbers.Count > 0)
            {
                sum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Stack<string> stack = new Stack<string>(input.Reverse());
            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string curPop = stack.Pop();

                if (curPop == "+")
                {
                    result += int.Parse(stack.Pop());
                }
                else if (curPop == "-")
                {
                    result -= int.Parse(stack.Pop());
                }

            }

            Console.WriteLine(result);


        }
    }
}

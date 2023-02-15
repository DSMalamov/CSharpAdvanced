using System;
using System.Collections.Generic;

namespace _1.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversed = new Stack<char>();

            foreach (var ch in input)
            {
                reversed.Push(ch);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reversed.Pop());
            }
            
        }
    }
}

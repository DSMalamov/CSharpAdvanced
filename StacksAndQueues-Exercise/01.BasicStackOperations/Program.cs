using System;
using System.Collections.Generic;
using System.Linq;

int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int elemToPush = input[0];
int elemToPop = input[1];
int elemToPeak = input[2];

Stack<int> stack = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

for (int i = 0; i < elemToPop; i++)
{
    stack.Pop();
}

if (stack.Contains(elemToPeak))
{
    Console.WriteLine("true");
}
else if (!stack.Any())
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(stack.Min());
}
    


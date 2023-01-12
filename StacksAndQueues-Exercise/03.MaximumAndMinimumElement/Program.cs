using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
Stack<int> stack = new();

for (int i = 0; i < n; i++)
{
    int[] command = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int commandType = command[0];

    if (commandType == 1)
    {
        int number = command[1];
        stack.Push(number);
    }
    else if (commandType == 2)
    {
        if (stack.Any())
        {
            stack.Pop();
        }
        
    }
    else if (commandType == 3)
    {
        if (stack.Any())
        {
            Console.WriteLine(stack.Max());
        }
        
    }
    else if (commandType == 4)
    {
        if (stack.Any())
        {
            Console.WriteLine(stack.Min());
        }
        
    }
        
}

Console.WriteLine(string.Join(", ", stack));

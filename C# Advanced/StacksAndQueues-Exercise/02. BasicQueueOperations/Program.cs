using System;
using System.Collections.Generic;
using System.Linq;

int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int elemToEnque = input[0];
int elemToDeque = input[1];
int elemToPeak = input[2];

Queue<int> queue = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

for (int i = 0; i < elemToDeque; i++)
{
    queue.Dequeue();
}

if (queue.Contains(elemToPeak))
{
    Console.WriteLine("true");
}
else if (!queue.Any())
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(queue.Min());
}

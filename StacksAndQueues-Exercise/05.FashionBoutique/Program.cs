using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> clothes = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int rackSize = int.Parse(Console.ReadLine());
int currRS = rackSize; //space left on the rack
int rackCounter = 1;
while (clothes.Any())
{
    int currSize = clothes.Peek();

    if (currRS >= currSize)
    {
        clothes.Pop();
        currRS -= currSize;
    }
    else
    {
        currRS = rackSize;
        rackCounter++;
    }
}

Console.WriteLine(rackCounter);

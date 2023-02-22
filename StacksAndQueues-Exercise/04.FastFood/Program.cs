using System;
using System.Collections.Generic;
using System.Linq;

int foodQuantity = int.Parse(Console.ReadLine());

Queue<int> queue = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Console.WriteLine(queue.Max());

while (queue.Any())
{
    int currFood = queue.Peek();

    if (foodQuantity - currFood >= 0)
    {
        queue.Dequeue();
        foodQuantity -= currFood;
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
        break;
    }
}

if (!queue.Any())
{
    Console.WriteLine("Orders complete");
}



    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeInput = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milkInput = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> table = new Dictionary<string, int>();
            Dictionary<string, int> drinksMade = new Dictionary<string, int>();
            table.Add("Cortado", 50);
            table.Add("Espresso", 75);
            table.Add("Capuccino", 100);
            table.Add("Americano", 150);
            table.Add("Latte", 200);
            drinksMade.Add("Cortado", 0);
            drinksMade.Add("Espresso", 0);
            drinksMade.Add("Capuccino", 0);
            drinksMade.Add("Americano", 0);
            drinksMade.Add("Latte", 0);

            Console.WriteLine();

            while (coffeeInput.Count > 0 && milkInput.Count > 0)
            {
                int coffee = coffeeInput.Dequeue();
                int milk = milkInput.Pop();
                int sum = milk + coffee;
                bool isFound = true;

                foreach (var item in table)
                {
                    if (item.Value == sum)
                    {
                        drinksMade[item.Key] += 1;
                        isFound = false;
                    }
                }

                if (isFound)
                {
                    milk -= 5;
                    milkInput.Push(milk);
                }

            }

            if (coffeeInput.Count <= 0 && milkInput.Count <= 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeInput.Count > 0)
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeInput)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkInput.Count > 0)
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkInput)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            drinksMade = drinksMade.OrderBy(y => y.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in drinksMade)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}

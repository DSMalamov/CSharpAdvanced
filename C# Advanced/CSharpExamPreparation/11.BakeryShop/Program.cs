using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _11.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, double> list = new Dictionary<string, double>();
            list.Add("Croissant", 50);
            list.Add("Muffin", 40);
            list.Add("Baguette", 30);
            list.Add("Bagel", 20);
            Dictionary<string, int> made = new Dictionary<string, int>();
            made.Add("Croissant", 0);
            made.Add("Muffin", 0);
            made.Add("Baguette", 0);
            made.Add("Bagel", 0);

            while (water.Count>0 && flour.Count>0)
            {
                double cWater = water.Dequeue();
                double cFlour = flour.Pop();
                double sum = cWater + cFlour;
                double cPer = (cWater * 100) / sum;
                bool isMade = true;
                foreach (var kvp in list)
                {
                    if (kvp.Value == cPer)
                    {
                        made[kvp.Key]++;
                        isMade= false;
                        break;

                    }
                }

                if (isMade)
                {
                    if (cFlour > cWater)
                    {
                        flour.Push(cFlour - cWater);
                        made["Croissant"]++;
                    }
                }

            }

            foreach (var kvp in made.Where(v => v.Value > 0).OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: { string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<Sword> list= new List<Sword>();
            list.Add(new Sword("Gladius", 70));
            list.Add(new Sword("Shamshir", 80));
            list.Add(new Sword("Katana", 90));
            list.Add(new Sword("Sabre", 110));
            list.Add(new Sword("Broadsword", 150));
            bool isMade = false;
            int counterOfSwords = 0;

            while (steel.Any() && carbon.Any())
            {
                isMade = false;
                int currStreel = steel.Dequeue();
                int currCarbon = carbon.Pop();
                int sum = currStreel + currCarbon;

                foreach (var item in list)
                {
                    if (sum == item.Value)
                    {
                        item.Count++;
                        isMade= true;
                        counterOfSwords++;
                    }
                }

                if (!isMade)
                {
                    currCarbon += 5;
                    carbon.Push(currCarbon);
                }
            }

            if (counterOfSwords > 0)
            {
                Console.WriteLine($"You have forged {counterOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (counterOfSwords > 0)
            {
                foreach (var item in list.OrderBy(n => n.Name).Where(s => s.Count > 0))
                {
                    Console.WriteLine($"{item.Name}: {item.Count}");
                }
            }


        }

        
    }

    public class Sword
    {
        public Sword(string name, int value)
        {
            Name = name;
            Value = value;
            Count = 0;
        }

        public string Name { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
}

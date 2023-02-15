using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _07.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Location> list = new List<Location>();

            list.Add(new Location("Sink", 40));
            list.Add(new Location("Oven", 50));
            list.Add(new Location("Countertop", 60));
            list.Add(new Location("Wall", 70));
            list.Add(new Location("Floor", 0));

            Stack<int> white = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> grey = new Queue<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            

            while (white.Count > 0 && grey.Count > 0)
            {
                int currWhite = white.Pop();
                int currGrey = grey.Dequeue();

                if (currWhite == currGrey) 
                {
                    int currSum = currWhite + currGrey;

                    if (list.Any(p => p.Size == currSum))
                    {
                        Location location = list.First(p => p.Size == currSum);
                        location.Count++;
                    }
                    else
                    {
                        Location location = list.First(p => p.Name == "Floor");
                        location.Count++;
                    }
                }
                else
                {
                    white.Push(currWhite/2);
                    grey.Enqueue(currGrey);
                }
            }

            if (white.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (grey.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var item in list.OrderByDescending(p => p.Count).ThenBy(p => p.Name))
            {
                if (item.Count > 0)
                {
                    Console.WriteLine($"{item.Name}: {item.Count}");
                }
                
            }

        }


    }

    public class Location
    {
        public Location(string name, int size)
        {
            Name = name;
            Size = size;
            Count = 0;
        }

        public string Name { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
    }

}

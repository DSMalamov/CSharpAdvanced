using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<int> guests = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wastedFood = 0;
            int leftover = 0;
            bool isFed = false;

            while (plates.Count > 0 && guests.Count > 0)
            {
                isFed = false;
                int currPlate = plates.Pop();
                int currGuest = guests.Peek();

                if (currPlate >= currGuest)
                {
                    guests.Dequeue();

                    if (currPlate - currGuest > 0 )
                    {
                        wastedFood += currPlate - currGuest;
                    }
                }
                else
                {
                    while (!isFed && plates.Count>0)
                    {
                        currGuest -= currPlate;
                        currPlate = plates.Pop();

                        if (currPlate - currGuest > 0)
                        {
                            isFed = true;
                            guests.Dequeue();
                            wastedFood += currPlate - currGuest;
                        }
                        else
                        {
                            currGuest -= currPlate;
                        }

                    }

                    
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}

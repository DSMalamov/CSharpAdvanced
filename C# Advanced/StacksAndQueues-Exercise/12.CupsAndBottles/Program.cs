namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new(bottlesCapacity);
            Queue<int> cups = new(cupsCapacity);
            int wastedLiters = 0;

            while (cups.Any())
            {
                int cup = cups.Peek();

                while (cup > 0)
                {
                    int bottle = 0;

                    if (bottles.Any())
                    {
                        bottle = bottles.Pop();
                    }
                    else
                    {
                        Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                        Console.WriteLine($"Wasted litters of water: {wastedLiters}");
                        return;
                    }
                   

                    if (cup <= bottle)
                    {
                        cups.Dequeue();
                        wastedLiters += bottle - cup;
                        cup -= bottle;

                    }
                    else if (cup > bottle)
                    {
                        cup -= bottle;
                    }

                    
                }

            }

            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLiters}");

        }
    }
}
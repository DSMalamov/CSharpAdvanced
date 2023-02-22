namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(input);
            }

            int start = 0;

            while (true)
            {
                bool isComplete = true;
                int totalLiters = 0;

                foreach (var pump in queue)
                {
                    int liters = pump[0];
                    int distance = pump[1];

                    totalLiters += liters;

                    if (totalLiters - distance < 0)
                    {
                        start++;

                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);

                        isComplete = false;

                        break;
                    }

                    totalLiters -= distance;
                }

                if (isComplete)
                {
                    Console.WriteLine(start);
                    break;
                }
            }
        }
    }
}
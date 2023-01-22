namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in currInput)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
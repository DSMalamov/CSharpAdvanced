namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new();
            HashSet<int> secondSet = new();

            for (int i = 0; i < size[0]; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                firstSet.Add(currNum);
            }

            for (int i = 0; i < size[1]; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                secondSet.Add(currNum);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(String.Join(" ", firstSet));
        }
    }
}
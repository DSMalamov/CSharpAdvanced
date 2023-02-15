namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                uniqueNames.Add(name);

            }

            foreach (string uniqueName in uniqueNames) 
            {
                Console.WriteLine(uniqueName);
            }
        }
    }
}
namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> charCount = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!charCount.ContainsKey(ch))
                {
                    charCount.Add(ch, 0);
                }

                charCount[ch]++;

            }

            foreach (var item in charCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }


        }
    }
}
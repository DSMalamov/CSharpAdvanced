namespace _04._EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var numberCount = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int curN = int.Parse(Console.ReadLine());

                if (!numberCount.ContainsKey(curN))
                {
                    numberCount.Add(curN, 0);
                }

                numberCount[curN]++;
            }

            Console.WriteLine(numberCount.Single(n => n.Value % 2 == 0).Key);
        }
    }
}
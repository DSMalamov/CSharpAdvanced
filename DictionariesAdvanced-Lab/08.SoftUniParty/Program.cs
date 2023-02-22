using Microsoft.VisualBasic;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> normal = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                char firstLetter = input[0];

                if (Char.IsDigit(firstLetter))
                {
                    vip.Add(input);
                }
                else
                {
                    normal.Add(input);
                }

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                char firstLetter = input[0];

                if (Char.IsDigit(firstLetter))
                {
                    vip.Remove(input);
                }
                else
                {
                    normal.Remove(input);
                }

                input = Console.ReadLine();
            }

            int sum = vip.Count + normal.Count;

            Console.WriteLine(sum);

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in normal)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
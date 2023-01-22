using System;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothesByColor = new();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] {" -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string curColor = input[0];

                if (!clothesByColor.ContainsKey(curColor))
                {
                    clothesByColor.Add(curColor, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string currCloth = input[j];

                    if (!clothesByColor[curColor].ContainsKey(currCloth))
                    {
                        clothesByColor[curColor].Add(currCloth, 0);
                    }

                    clothesByColor[curColor][currCloth]++;
                }
            }
            string[] lookingFor = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in clothesByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");

                    if (color.Key == lookingFor[0] && cloth.Key == lookingFor[1])
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            Dictionary<string, List<char>> dict = new Dictionary<string, List<char>>();

            dict.Add("pear", new List<char>() {'p','e', 'a', 'r' });
            dict.Add("flour", new List<char>() { 'f', 'l', 'o', 'u', 'r' });
            dict.Add("pork", new List<char>() { 'p', 'o', 'r', 'k' });
            dict.Add("olive", new List<char>() { 'e', 'l', 'o', 'i', 'v' });

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currCon = consonants.Pop();

                foreach (var word in dict.Keys)
                {
                    foreach (var item in word)
                    {
                        if (item == currVowel || item == currCon)
                        {
                            dict[word].Remove(item);
                        }
                    }
                }

                vowels.Enqueue(currVowel);
            }

            int counter = dict.Values.Where(x => x.Count == 0).Count();

            Console.WriteLine($"Words found: {counter}");
            foreach (var item in dict)
            {
                if (item.Value.Count == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}

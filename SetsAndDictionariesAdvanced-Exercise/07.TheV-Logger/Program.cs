namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vlogers = new();

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArg[1] == "joined")
                {
                    string name = cmdArg[0];

                    if (!vlogers.ContainsKey(name))
                    {
                        vlogers.Add(name, new Dictionary<string, SortedSet<string>>());
                        vlogers[name].Add("fallowing", new SortedSet<string>());
                        vlogers[name].Add("fallowers", new SortedSet<string>());
                    }
                }
                else if (cmdArg[1] == "followed")
                {
                    string first = cmdArg[0];
                    string second = cmdArg[2];

                    if (vlogers.ContainsKey(first)
                        && vlogers.ContainsKey(second)
                        && first != second) 
                    {
                        vlogers[first]["fallowing"].Add(second);
                        vlogers[second]["fallowers"].Add(first);
                    }

                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            var sortedVlogers = vlogers
                .OrderByDescending(x => x.Value["fallowers"].Count())
                .ThenBy(x => x.Value["fallowing"].Count)
                .ToDictionary(x => x.Key, x => x.Value);
            int count = 1;

            foreach (var vloger in sortedVlogers)
            {
                Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value["fallowers"].Count} followers, {vloger.Value["fallowing"].Count} following");

                if (count == 1)
                {
                    

                    foreach (var item in vloger.Value["fallowers"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                    
                }

                count++;
            }
        }
    }
}
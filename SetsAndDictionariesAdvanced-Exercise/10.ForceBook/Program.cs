using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> userSide = new SortedDictionary<string, SortedSet<string>>();

            string command;

            while ((command = Console.ReadLine()) != "Lumpawaroo") 
            {

                if (command.Contains(" | "))
                {
                    string[] cmdArg = command
                    .Split(" | ", StringSplitOptions.RemoveEmptyEntries); 

                    string user = cmdArg[1];
                    string side = cmdArg[0];

                    if (!userSide.Values.Any(u => u.Contains(user)))
                    {
                        if (!userSide.ContainsKey(side))
                        {
                            userSide.Add(side, new SortedSet<string>());
                        }

                        userSide[side].Add(user);
                    }
                }
                else if (command.Contains(" -> ")) 
                {
                    string[] cmdArg = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string user = cmdArg[0];
                    string side = cmdArg[1];

                    foreach (var currSide in userSide)
                    {
                        if (currSide.Value.Contains(user))
                        {
                            currSide.Value.Remove(user);
                            break;
                        }
                    }

                    if (!userSide.ContainsKey(side))
                    {
                        userSide.Add(side, new SortedSet<string>());
                    }
                    userSide[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedUserSide = userSide.OrderByDescending(s => s.Value.Count).ToDictionary(s => s.Key, s => s.Value);

            foreach (var side in orderedUserSide)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    foreach (var users in side.Value)
                    {
                        Console.WriteLine($"! {users}");
                    }
                }

                
            }
        }
    }
}
using System.Security.Cryptography.X509Certificates;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new();
            SortedDictionary<string, Dictionary<string, int>> studentsScore = new();

            string command;

            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] cmdArg = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = cmdArg[0];
                string password = cmdArg[1];
                

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArg = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = cmdArg[0];
                string password = cmdArg[1];
                string student = cmdArg[2];
                int score = int.Parse(cmdArg[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!studentsScore.ContainsKey(student))
                    {
                        studentsScore.Add(student, new Dictionary<string, int>());
                    }

                    if (!studentsScore[student].ContainsKey(contest))
                    {
                        studentsScore[student].Add(contest, 0);
                    }

                    if (studentsScore[student][contest] < score)
                    {
                        studentsScore[student][contest] = score;
                    }
                }

            }

            string bestCandidate = studentsScore.MaxBy(x => x.Value.Values.Sum()).Key;

            Console.WriteLine($"Best candidate is {bestCandidate} with total {studentsScore[bestCandidate].Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in studentsScore)
            {
                Console.WriteLine(student.Key);

                var dictionary = student.Value
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var contest in dictionary)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
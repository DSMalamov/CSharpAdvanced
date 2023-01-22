namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> participantsPoints = new();
            SortedDictionary<string, int> submissionsCount = new();

            string command;

            while ((command = Console.ReadLine()) != "exam finished") 
            {
                string[] cmdArg = command
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArg[0];

                if (cmdArg[1] == "banned")
                {
                    participantsPoints.Remove(name);
                    continue;
                }

                string submission = cmdArg[1];
                int points = int.Parse(cmdArg[2]);

                if (!participantsPoints.ContainsKey(name))
                {
                    participantsPoints.Add(name, 0);
                }

                if (participantsPoints[name] < points)
                {
                    participantsPoints[name] = points;
                }

                if (!submissionsCount.ContainsKey(submission))
                {
                    submissionsCount.Add(submission, 0);
                }

                submissionsCount[submission]++;

            }

            Console.WriteLine("Results:");

            foreach (var participant in participantsPoints.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in submissionsCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
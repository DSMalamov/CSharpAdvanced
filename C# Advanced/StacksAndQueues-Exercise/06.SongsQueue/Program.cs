namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Any())
            {
                string[] commnad = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = commnad[0];

                if (cmdArg == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmdArg == "Add")
                {
                    string song = string.Join(" ", commnad.Skip(1));

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }

                }
                else if (cmdArg == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                
            }

            Console.WriteLine("No more songs!");
        }
    }
}
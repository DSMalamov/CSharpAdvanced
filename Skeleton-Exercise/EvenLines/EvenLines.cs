namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new(inputFilePath))
            {
                string line = String.Empty;
                int count = 0;

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (count % 2 == 0)
                    {
                        string reaplacedSym = ReplaceSymbols(line);
                        string reversedLine = ReversedLine(reaplacedSym);
                        sb.AppendLine(reversedLine);
                    }
                }

                return sb.ToString().TrimEnd();
                
            }
        }

        private static string ReversedLine(string reaplacedSym)
        {
            string[] reversed = reaplacedSym
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(" ", reversed);
        }

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);

            string[] chars = { "-", ",", ".", "!", "?" };

            foreach (var item in chars)
            {
                sb = sb.Replace(item, "@");
            }

            return sb.ToString();
        }
    }
}

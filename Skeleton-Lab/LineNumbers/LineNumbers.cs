namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {

            using (var input = new StreamReader(inputFilePath))
            {
                string line = input.ReadLine();
                int num = 1;

                
                    using (var output = new StreamWriter(outputFilePath))
                    {
                        while (line != null)
                        {
                            output.WriteLine($"{num}. {line}");
                            num++;
                            line = input.ReadLine();
                        }
                        
                    }
                
                


            }


        }
    }
}

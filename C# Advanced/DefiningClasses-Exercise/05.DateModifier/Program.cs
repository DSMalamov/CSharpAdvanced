namespace _05.DateModifier
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            

            int[] input1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var date11 = new DateTime(input1[0], input1[1], input1[2]);
            var date22 = new DateTime(input2[0], input2[1], input2[2]);
            
            DateModifier date = new(date11, date22);

            Console.WriteLine(Math.Abs(date.GetDifference()));
            
        }
    }
}
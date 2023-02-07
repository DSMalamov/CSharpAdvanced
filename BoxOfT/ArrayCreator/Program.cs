namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] joros = ArrayCreator.Create(15, "joro");

            Console.WriteLine(String.Join(" ", joros));
        }
    }
}
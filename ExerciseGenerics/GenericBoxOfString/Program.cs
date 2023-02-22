namespace GenericBoxOfString;

internal class Program
{
    static void Main(string[] args)
    {
        Box<string> box = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string item = Console.ReadLine();
            box.Add(item);
        }

        Console.WriteLine(box.ToString());
    }
}
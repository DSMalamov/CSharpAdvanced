namespace _01.CurstomList;

internal class Program
{
    static void Main(string[] args)
    {
        CustomList customLits= new CustomList();

        customLits.Add(5);
        customLits.Add(4);
        customLits.Add(3);
        customLits.Add(2);
        customLits.InsertAt(1, 11);
        customLits.Swap(1, 3);
        
    }
}
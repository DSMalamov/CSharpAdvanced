namespace _02.CustomStack;

internal class Program
{
    static void Main(string[] args)
    {
        CustomStack stack = new CustomStack();

        stack.Push(1);
        stack.Push(2);
        stack.ForEach(x => stack.Push(x));  
    }
}
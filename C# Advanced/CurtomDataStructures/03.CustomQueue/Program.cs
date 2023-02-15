namespace _03.CustomQueue;

internal class Program
{
    static void Main(string[] args)
    {
        CustomQueue queue = new CustomQueue();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Dequeue();
        queue.Clear();
        Console.WriteLine(queue.Count);

    }
}
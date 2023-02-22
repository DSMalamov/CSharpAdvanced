using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack;

public class CustomStack
{
    private const int InitialCapacity = 4;
    private int[] items;

    public CustomStack()
    {
        items= new int[InitialCapacity];
    }

    public int Count { get; private set; }

    public void Push(int item)
    {
        if (items.Length == Count)
        {
            Resize();
        }

        items[Count] = item;

        Count++;
    }

    public int Pop()
    {
        if (Count == 0) 
        {
            throw new InvalidOperationException("CustomStack is empty"); 
        }

        int lastItem = items[Count - 1];

        items[Count - 1] = default;

        Count--;

        return lastItem;
    }

    public void ForEach(Action<int> action)
    {
        for (int i = 0; i < Count; i++)
        {
            action(this.items[i]);
        }
    }

    public int Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("CustomStack is empty");
        }
        return items[Count - 1];
    }

    private void Resize()
    {
        int[] copy = new int[items.Length * 2];

        for (int i = 0; i < Count; i++)
        {
            copy[i] = items[i];
        }

        items = copy;
    }
}

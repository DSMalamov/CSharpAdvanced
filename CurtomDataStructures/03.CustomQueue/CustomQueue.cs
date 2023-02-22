using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomQueue;

public class CustomQueue
{
    private const int InitialCapacity = 4;
    private int[] items;

    public CustomQueue()
    {
        items = new int[InitialCapacity];
    }

    public int Count { get; private set; }

    public void Enqueue(int item)
    {
        if (items.Length == Count)
        {
            Resize();
        }

        items[Count] = item;

        Count++;
    }

    public int Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("CustomStack is empty");
        }

        int firstItem = items[0];

        items[0] = default;

        ShiftLeft();

        Count--;

        return firstItem;

    }

    public int Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("CustomStack is empty");
        }
        return items[0];
    }

    public void Clear()
    {
        items = new int[InitialCapacity];
        Count = 0;
    }

    public void ForEach(Action<int> action)
    {
        for (int i = 0; i < Count; i++)
        {
            action(this.items[i]);
        }
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

    private void ShiftLeft()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        for (int i = Count - 1; i < items.Length; i++)
        {
            items[i] = default;
        }
    }
}

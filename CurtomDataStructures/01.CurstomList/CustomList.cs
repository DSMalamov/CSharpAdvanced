using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _01.CurstomList;

public class CustomList
{
    private const int InitialCapacity = 2;

    private int[] items;

    public CustomList()
    {
        items = new int[InitialCapacity];
    }

    public int Count { get; private set; }

    public int this[int index] 
    { 
        get 
        {
            ValidateIndex(index);
            return items[index];
        }
        set 
        {
            ValidateIndex(index);
            items[index] = value;
        }
    }

    public void Add(int item)
    {
        if (items.Length == Count)
        {
            Resize();
        }

        items[Count] = item;

        Count++;

    }

    public int RemoveAt(int index)

    {
        int removedItem = items[index];

        ValidateIndex(index);

        items[index] = default;

        Count--;

        if (Count <= items.Length / 4)
        {
            Shrink();
        }

        ShiftLeft(index);

        return removedItem;
    }

    public void InsertAt(int index, int item)
    {
        ValidateIndex(index);

        Resize();

        ShiftRight(index);

        Count++;

        items[index] = item;
    }

    public bool Contains(int item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (items[i] == item)
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        ValidateIndex(index1);
        ValidateIndex(index2);

        int copy = items[index1];
        items[index1] = items[index2];
        items[index2] = copy;
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

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < Count; i++)
        {
            items[i] = items[i + 1];
        }
        for (int i = Count; i < items.Length; i++)
        {
            items[i] = default;
        }
    }

    private void ShiftRight(int index)
    {
        for (int i = Count + 1; i > index; i--)
        {
            items[i] = items[i - 1];
        }
    }

    private void Shrink()
    {
        int[] copy = new int[items.Length / 2];

        for (int i = 0; i < Count; i++)
        {
            copy[i] = items[i];
        }

        items = copy;
    }
}




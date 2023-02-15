using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitalCapacity = 4;
        private T[] stack;

        public CustomStack()
        {
            stack = new T[InitalCapacity];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (stack.Length == Count)
            {
                Resize();
            }

            stack[Count] = item;

            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removedItem = stack[Count - 1];

            Count--;

            return removedItem;

        }

        private void Resize()
        {
            T[] newStack = new T[stack.Length * 2];

            for (int i = 0; i < stack.Length; i++)
            {
                newStack[i] = stack[i];
            }

            stack = newStack;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

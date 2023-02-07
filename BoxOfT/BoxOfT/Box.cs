using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;
        private int count;
        public Box()
        {
            list = new List<T>();
        }
        public int Count { get { return this.count; } }

        public void Add(T element)
        {
            count++;
            list.Add(element);
        }

        public T Remove()
        {
            count--;
            T removedEl = list[list.Count - 1];
            list.Remove(removedEl);

            return removedEl;
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGetCountMethodDouble
{
    internal class Box<T> where T : IComparable<T> 
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Swap(int index1, int index2)
        {
            (list[index1], list[index2]) = (list[index2], list[index1]);

        }

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (T item in list)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in list)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

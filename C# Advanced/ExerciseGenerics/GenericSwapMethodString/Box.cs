using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodString;

public class Box<T>
{
    private List<T> list;

	public Box()
	{
		list= new List<T>();
	}

	public void Add(T item)
	{
		list.Add(item);
	}

	public void Swap(int index1, int index2)
	{
		T item = list[index1];
		list[index1] = list[index2];
		list[index2] = item;
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

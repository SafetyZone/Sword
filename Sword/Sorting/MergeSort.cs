using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting
{
	public class MergeSort<T> where T : IComparable<T>
	{
		public void Sort(T[] array)
		{
			
		}


		public T[] MergeAB(T[] a, T[] b)
		{
			var c = new T[a.Length + b.Length];
			for (int i = 0, j = 0, k = 0; k < a.Length + b.Length; k++)
			{
				if (i == a.Length) { c[k] = b[j++]; continue; }
				if (j == b.Length) { c[k] = a[i++]; continue; }
				c[k] = (a[i].CompareTo(b[j]) < 0) ? a[i++] : b[j++];
			}

			return c;
		}
	}
}

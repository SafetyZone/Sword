using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting.Exchange
{
	public class QSortStack : SortingAlg
	{
		public override int[] Sort(int[] array)
		{
			sort(array, 0, array.Length - 1);
			return array;
		}

		private void sort(int[] a, int l, int r)
		{
			Stack<int> stack = new Stack<int>(10);
			stack.Push(l);
			stack.Push(r);
			while (stack.Count != 0)
			{
				int e = stack.Pop();
				int s = stack.Pop();

				int m = Partition(a, s, e);

				if (s == e)
					continue;
				if (m - s > 1)
				{
					stack.Push(s);
					stack.Push(m - 1);
				}

				if (e - m > 1)
				{
					stack.Push(m + 1);
					stack.Push(e);
				}

			}
		}

		private int Partition(int[] a, int l, int r)
		{
			int i = l - 1;
			int j = r;
			int m = a[r];

			while (true)
			{
				while (a[++i] < m) ;

				while (m < a[--j])
					if (j == l)
						break;

				if (i >= j)
					break;

				int tmp = a[i];
				a[i] = a[j];
				a[j] = tmp;
			}
			int tmp2 = a[i];
			a[i] = a[r];
			a[r] = tmp2;

			return i;
		}

		public override string Name
		{
			get { throw new NotImplementedException(); }
		}
	}
}

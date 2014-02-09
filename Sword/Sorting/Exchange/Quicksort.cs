using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting.Exchange
{
	public class CormanQuicksort : SortingAlg
	{
		public override int[] Sort(int[] array)
		{
			qsort(array, 0, array.Length - 1);
			return array;
		}

		private void qsort(int[] a, int p, int r)
		{
			if (p < r)
			{
				int q = Partition(a, p, r);
				qsort(a, p, q);
				qsort(a, q + 1, r);
			}
		}

		private int Partition(int[] a, int p, int r)
		{
			int x = a[r];
			int i = p;
			for (int j = p; j <= r - 1; j++)
				if (a[j] <= x)
				{
					int tmp = a[i];
					a[i] = a[j];
					a[j] = tmp;
					i++;
				}
			int tmp1 = a[i];
			a[i] = a[r];
			a[r] = tmp1;
			return i;
		}

		public override string Name
		{
			get { return "Quicksort"; }
		}
	}
}

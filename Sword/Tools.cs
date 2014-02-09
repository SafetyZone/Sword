using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sword.LinkedList;
using Sword.Tree.BT;
using Node = Sword.Tree.BT.Node;

namespace Sword
{
	public static class T
	{
		public static void W(object value)
		{
			System.Diagnostics.Debug.Write(value);
		}
		public static void N()
		{
			N(string.Empty);
		}
		public static void N(object value)
		{
			System.Diagnostics.Debug.WriteLine(value);
		}

		public static int[] SortedArrray(int count)
		{
			return SortedArrray(0, count);
		}

		public static int[] SortedArrray(int from, int count)
		{
			int[] ret = new int[count - from];
			for (int i = from; i < count; i++)
				ret[i - from] = i;
			return ret;
		}

		public static void PringBinaryTree(Tree.BT.Node root)
		{
			var list = Tests.LinkedListOfNodes(root);

			byte WSLen = 1;
			byte VALLen = 3;
			int maxLevel = list.Count;
			foreach (var linkedList in list)
			{
				int subNumCount = (int)(Math.Pow(2, maxLevel-1)) - 1;
				int subWSCount = subNumCount * VALLen + subNumCount * WSLen + WSLen;
				string wsPre = new string(' ', subWSCount);
				string wsAfter = new string(' ', subWSCount);
				string numws = new string(' ', VALLen);
				maxLevel--;
                //int count = 0;
				foreach (Node node in linkedList)
				{
					W(wsPre);
					if (node.Value >= 0)
						W(node.Value.ToString("000"));
					else
						W(node.Value.ToString("00"));
					W(wsAfter);
					W(numws);

				}
				N("");
			}
		}

        public static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                T.W(i);
                T.W(";");
            }
            T.N();
        }

	}
}

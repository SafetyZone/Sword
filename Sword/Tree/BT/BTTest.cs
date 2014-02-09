using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Tree.BT
{
	public static class BTTest
	{
		public static void Test1()
		{
			var bt = new BinaryTree();

			foreach (var i in new[] { 8, 3, 1, 6, 4, 7 })
			{
				bt.Insert(i);
			}

			T.W(bt.Find(10));
			T.W(bt.Find(6));
			T.W(bt.Find(100));

			bt.Delete(8);
		}
	}
}

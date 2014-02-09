using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Tree.BT
{
	public class Node
	{
		public int Value;

		public Node Parent;

		public Node Left;

		public Node Right;

		public Node(int value) : this(value, null) { }
		public Node(int value, Node parent)
		{
			this.Value = value;
			this.Parent = parent;
		}

		public override string ToString()
		{
			if (Left == null && Right == null)
			return Value + ";\r\n";
			string ret = string.Empty;
			if (Left != null)
				ret += Value + " -> " + Left.Value + ";\r\n" + Left;
			//else
			//    ret += Value + " -> null;\r\n";
			if (Right != null)
				ret += Value + " -> " + Right.Value + ";\r\n" + Right;
			//else
			//    ret += Value + " -> null;\r\n";
			return ret;
		}

	}
}

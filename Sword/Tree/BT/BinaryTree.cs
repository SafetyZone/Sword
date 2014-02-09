using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Tree.BT
{
	public class BinaryTree
	{
		public BinaryTree()
		{

		}
		public BinaryTree(Node root)
		{
			Root = root;
		}

		public Node Root { get; set; }

		public Node Find(int value)
		{
			var parent = Root;
			while (true)
			{
				if (parent == null)
				{
					return null;
				}

				if (parent.Value == value)
				{
					return parent;
				}

				if (parent.Value > value)
				{
					parent = parent.Left;
					continue;
				}
				parent = parent.Right;
			}
		}

		public void Insert(int value)
		{
			if (Root == null)
			{
				Root = new Node(value);
				return;
			}

			var parentNode = Root;

			while (true)
			{
				if (parentNode.Value > value)
				{
					if (parentNode.Left == null)
					{
						parentNode.Left = new Node(value, parentNode);
					}
					else
					{
						parentNode = parentNode.Left;
						continue;
					}
				}
				else
				{
					if (parentNode.Right == null)
					{
						parentNode.Right = new Node(value, parentNode);
					}
					else
					{
						parentNode = parentNode.Right;
						continue;
					}
				}
				break;
			}

		}

		public bool Delete(int p)
		{
			Node parent = null;
			var current = Root;

			// find node;
			while (true)
			{
				if (current == null)
				{
					return false;
				}

				if (current.Value == p)
				{
					break;
				}

				if (current.Value > p)
				{
					parent = current;
					current = current.Left;
				}
				else
				{
					parent = current;
					current = current.Right;
				}
			}

			if (current.Right == null)
			{
				if (parent == null)
				{
					Root = current.Left;
				}
				else
				{
					if (parent.Value > current.Value)
					{
						parent.Left = current.Left;
					}
					else
					{
						parent.Right = current.Left;
					}
				}
			}
			else if (current.Right.Left == null)
			{
				if (parent == null)
				{
					Root = current.Right;
				}
				else
				{
					if (parent.Value > current.Value)
					{
						parent.Left = current.Right;
					}
					else
					{
						parent.Right = current.Right;
					}
				}
			}
			else
			{
				var leftmost = current.Right.Left;
				var lmParent = current.Right;

				while (leftmost.Left != null)
				{
					lmParent = leftmost;
					leftmost = leftmost.Left;
				}

				lmParent.Left = leftmost.Right;

				// assign leftmost's left and right to current's left and right children
				leftmost.Left = current.Left;
				leftmost.Right = current.Right;

				if (parent == null)
					Root = leftmost;
				else
				{
					if (parent.Value > current.Value)
						parent.Left = leftmost;
					else
						parent.Right = leftmost;
				}
			}
			return true;
		}

		public bool IsBalanced()
		{
			int max = MaxHeight(Root);
			int min = MinHeight(Root);
			return max - min < 2;
		}

		public override string ToString()
		{
			if (Root != null)
				return Root.ToString();
			return "empty";
		}

		public static BinaryTree FromSotredArray(int[] array)
		{
			var bt = new BinaryTree(Add(array, 0, array.Length - 1));
			return bt;
		}

		public static Node RandomBinaryTree(Random rnd, int maxLevel, int level)
		{
			if (level > maxLevel)
				return null;
			var root = new Node(rnd.Next(20) - 10);
			root.Left = RandomBinaryTree(rnd, maxLevel, level + 1);
			root.Right = RandomBinaryTree(rnd, maxLevel, level + 1);
			return root;
		}

		public static Node Add(int[] data, int l, int r)
		{
			if (r < l)
			{
				return null;
			}

			var m = l + (r - l) / 2;

			var ret = new Node(data[m]);

			ret.Left = Add(data, l, m - 1);
			if (ret.Left != null)
				ret.Left.Parent = ret;

			ret.Right = Add(data, m + 1, r);
			if (ret.Right != null)
				ret.Right.Parent = ret;

			return ret;
		}

		public static int MinHeight(Node node)
		{
			if (node == null || node.Left == null && node.Right == null)
				return 0;
			return 1 + Math.Min(MinHeight(node.Left), MinHeight(node.Right));
		}

		public static int MaxHeight(Node node)
		{
			if (node == null || node.Left == null && node.Right == null)
				return 0;
			return 1 + Math.Max(MaxHeight(node.Left), MaxHeight(node.Right));
		}

		public static BinaryTree CopyFromNode(Node root, int cnt)
		{
			count = 0;
			maxcount = cnt;
			return new BinaryTree(CopyFromNode(root));
		}

		private static int count;
		private static int maxcount;

		private static Node CopyFromNode(Node root)
		{
			if (count > maxcount)
				return null;
			count++;
			if (root == null)
				return null;
			var to = new Node(root.Value);
			to.Left = CopyFromNode(root.Left);
			to.Right = CopyFromNode(root.Right);
			return to;
		}

	}
}
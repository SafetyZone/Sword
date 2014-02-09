using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Sword.Tree.BT
{
	public static class Tests
	{
		public static void BalancedBT()
		{
			var bt = new BinaryTree();

			//var data = new[] { 8, 3, 10, 6, 14, 4, 7, 13 };
			var data = new[] { 8, 6, 4, 3, 7, 13, 10, 14 };

			foreach (var i in data)
			{
				bt.Insert(i);
			}
			T.W(bt.ToString());
			T.W(bt.IsBalanced());
		}

		#region  CreateMinHFromsortedArray

		public static void CreateMinHFromsortedArray()
		{
			var arrays = new List<int[]>
			{
				new[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
				new[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 },
				new[]{ 1, 2, 3, 4, 5, 6, 7, 8 },
				new[]{ 1, 2, 3, 4, 5, 6, 7 },
				new[]{ 1, 2, 3, 4, 5, 6 },
				new[]{ 1, 2, 3, 4, 5 },
				new[]{ 1, 2, 3, 4 },
				new[]{ 1, 2, 3 },
				new[]{ 1, 2 },
				new[]{ 1 },
			};

			foreach (var array in arrays)
			{
				BinaryTree bt;
				bt = new BinaryTree(Add(array, 0, array.Length - 1));
				T.W(bt.ToString());
				T.W(bt.IsBalanced());
			}
		}


		public static void Add(BinaryTree bt, int[] data, int l, int r)
		{
			if (r < l)
			{
				return;
			}
			var m = l + (r - l) / 2;
			bt.Insert(data[m]);
			Add(bt, data, l, m - 1);
			Add(bt, data, m + 1, r);
		}

		public static Node Add(int[] data, int l, int r)
		{
			if (r < l)
			{
				return null;
			}

			var m = l + (r - l) / 2;

			return new Node(data[m])
			{
				Left = Add(data, l, m - 1),
				Right = Add(data, m + 1, r)
			};
		}

		#endregion

		#region Linked List of nodes
		/*Given a binary search tree, design an algorithm which creates 
		 * a linked list of all the nodes at each depth (i.e., if you 
		 * have a tree with depth D, you’ll have D linked lists).
		 */

		public static void LinkedListOfNodesTest()
		{
			var arr = new[] { 5, 2, 8, 1, 3, 6, 9, 4, 7, 10 };
			var bt = new BinaryTree();
			foreach (var i in arr)
			{
				bt.Insert(i);
			}
			var list = LinkedListOfNodes(bt.Root);

			foreach (LinkedList<Node> linkedList in list)
			{
				foreach (Node node in linkedList)
				{
					T.W(node.Value + " ");
				}
				T.N("");
			}
		}

		public static List<LinkedList<Node>> LinkedListOfNodes(Node root)
		{
			if (root == null)
				return null;

			var list = new List<LinkedList<Node>>();
			var linkedList = new LinkedList<Node>();

			linkedList.AddFirst(root);
			list.Add(linkedList);

			while (true)
			{
				var nll = new LinkedList<Node>(); // new linked list to add
				foreach (var node in linkedList)
				{
					if (node.Left != null)
						nll.AddLast(node.Left);
					if (node.Right != null)
						nll.AddLast(node.Right);
				}

				if (nll.Count == 0)
					break;
				list.Add(nll);
				linkedList = nll;
			}
			return list;
		}

		public static List<LinkedList<Node>> FullLinkedListOfNodes(Node root)
		{
			if (root == null)
				return null;

			var list = new List<LinkedList<Node>>();
			var linkedList = new LinkedList<Node>();

			linkedList.AddFirst(root);
			list.Add(linkedList);

			while (true)
			{
				var nll = new LinkedList<Node>(); // new linked list to add
				foreach (var node in linkedList)
				{
					if (node.Left != null)
						nll.AddLast(node.Left);
					if (node.Right != null)
						nll.AddLast(node.Right);
				}

				if (nll.Count == 0)
					break;
				list.Add(nll);
				linkedList = nll;
			}
			return list;
		}

		#endregion

		#region in-order successor
		/*
		 * Write an algorithm to find the ‘next’ node (i.e., in-order successor)
		 * of a given node in a binary search tree where each node has a link to its parent.
		 */

		public static void InOrderSuccessorTest()
		{
			var bt = BinaryTree.FromSotredArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			T.W(bt.ToString());
			var s = InOrderSuccessor(bt.Root, 4);
			T.W(s.ToString());
		}

		private static Node InOrderSuccessor(Node root, int value)
		{
			Node parent = null;

			while (true)
			{
				if (root == null)
					return null;
				if (root.Value == value)
					break;
				if (root.Value > value)
					root = root.Left;
				else
					root = root.Right;
			}

			if (root.Parent == null || root.Right != null)
			{
				root = root.Right;
				while (root.Left != null)
					root = root.Left;
				parent = root;
			}
			else
			{
				while (true)
				{
					parent = root.Parent;
					if (parent.Left != null && parent.Left.Value == root.Value)
						break;
					root = parent;
				}
			}
			return parent;
		}
		#endregion


		#region Common ancestor
		/*
		 * Design an algorithm and write code to find the first common ancestor 
		 * of two nodes in a binary tree. Avoid storing additional nodes in a data 
		 * structure. NOTE: This is not necessarily a binary search tree.
		 */

		public static void BSTCommonAncestorTest()
		{
			var bt = BinaryTree.FromSotredArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			T.W(bt.ToString());
			var s = BSTCommonAncestor(bt.Root, 3, 4);
			T.W(s.Value);
		}

		private static Node BSTCommonAncestor(Node root, int a, int b)
		{
			if (root == null)
				return null;
			if (root.Value > a && root.Value < b || root.Value > b && root.Value < a)
				return root;
			if (root.Value > a)
				return BSTCommonAncestor(root.Left, a, b);
			if (root.Value < a)
				return BSTCommonAncestor(root.Right, a, b);
			return root;
		}

		public static void BSTCommonAncestorParentTest()
		{
			var bt = BinaryTree.FromSotredArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			T.W(bt.ToString());
			T.W(BSTCommonAncestorParent(bt.Find(3), bt.Find(4)).Value);
			T.W(BSTCommonAncestorParent(bt.Find(3), bt.Find(6)).Value);
			T.W(BSTCommonAncestorParent(bt.Find(7), bt.Find(4)).Value);
			T.W(BSTCommonAncestorParent(bt.Find(1), bt.Find(3)).Value);
		}

		/// <summary>
		/// Groving from Nodes to parent. O(N^2)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		private static Node BSTCommonAncestorParent(Node a, Node b)
		{
			var atemp = a;

			while (true)
			{
				if (atemp.Value == b.Value)
				{
					return atemp;
				}

				if (atemp.Parent == null)
				{
					if (b.Parent == null)
						return null;
					b = b.Parent;
					atemp = a;
				}
				else
				{
					atemp = atemp.Parent;
				}
			}
		}


		public static void BTCommonAncestorCoversTest()
		{
			var bt = BinaryTree.FromSotredArray(T.SortedArrray(64));
			T.W(bt.ToString());
			T.N(BTCommonAncestorCovers(bt.Root, bt.Find(62), bt.Find(63)).Value);
		}

		private static int _btCovers = 0;
		private static Node BTCommonAncestorCovers(Node root, Node a, Node b)
		{
			T.N("BTCommonAncestorCovers " + root.Value + " " + a.Value + " " + b.Value);
			T.N(_btCovers);
			if (Covers(root.Left, a) && Covers(root.Left, b))
				return BTCommonAncestorCovers(root.Left, a, b);
			if (Covers(root.Right, a) && Covers(root.Right, b))
				return BTCommonAncestorCovers(root.Right, a, b);
			return root;
		}

		private static bool Covers(Node root, Node node)
		{
			if (root == null) return false;
			T.N("Covers" + root.Value + " " + node.Value);
			_btCovers++;
			if (root.Value == node.Value) return true;
			return Covers(root.Left, node) || Covers(root.Right, node);
		}

		#region Improved

		public static void BTCommonAncestorImprovedTest()
		{
			var bt = BinaryTree.FromSotredArray(T.SortedArrray(64));
			T.W(bt.ToString());
			T.N(BTCommonAncestorImproved(bt.Root, bt.Find(0), bt.Find(2)).Value == 1);
			T.N(BTCommonAncestorImproved(bt.Root, bt.Find(35), bt.Find(33)).Value == 35);
			T.N(BTCommonAncestorImproved(bt.Root, bt.Find(51), bt.Find(53)).Value == 51);
			T.N(BTCommonAncestorImproved(bt.Root, bt.Find(19), bt.Find(41)).Value == 31);
		}

		private static Node BTCommonAncestorImproved(Node root, Node p, Node q)
		{
			if (p == q && (root.Left == q || root.Right == p)) return root;

			int leftNodes = Covers(root.Left, p, q);

			if (leftNodes == 2)
			{
				if (root.Left == p || root.Left == q)
					return root.Left;
				return BTCommonAncestorImproved(root.Left, p, q);
			}
			if (leftNodes == 1)
			{
				return root;
			}

			int rightNodes = Covers(root, p, q);
			if (rightNodes == 2)
			{
				if (root.Right == p || root.Right == q)
					return root.Right;
				return BTCommonAncestorImproved(root.Right, p, q);
			}
			if (rightNodes == 1)
			{
				return root;
			}
			return null;
		}

		public static int Covers(Node root, Node p, Node q)
		{
			int ret = 0;
			if (root == null) return ret;
			if (root.Value == p.Value || root.Value == q.Value) ret += 1;
			ret += Covers(root.Left, p, q);

			if (ret == 2)
				return ret;
			return ret + Covers(root.Right, p, q);
		}

		#endregion
		#endregion

		#region SubTree

		public static void SubTreeTest()
		{
			var bt1 = BinaryTree.FromSotredArray(T.SortedArrray(1000));
			var bt2 = BinaryTree.CopyFromNode(bt1.Find(500), 300);
			bt2.Insert(900);
			T.N(bt1);
			T.N("");
			T.N(bt2);

			T.N(InSubtree(bt1.Root, bt2.Root));
		}

		public static bool InSubtree(Node r1, Node r2)
		{
			if (r1 == null || r2 == null)
				return false;

			var root = FindNode(r1, r2);
			return root != null && MatchTreeis(root, r2);
		}

		private static bool MatchTreeis(Node root, Node r2)
		{
			if (root == null && r2 == null || root != null && r2 == null)
				return true;
			if (root == null && r2 != null)
				return false;
			if (root.Value != r2.Value)
				return false;
			return (MatchTreeis(root.Left, r2.Left) && MatchTreeis(root.Right, r2.Right));
		}

		public static Node FindNode(Node root1, Node root2)
		{
			if (root1 == null)
				return null;
			if (root1.Value == root2.Value)
				return root1;
			var ret = FindNode(root1.Left, root2);
			if (ret == null)
				ret = FindNode(root1.Right, root2);
			return ret;
		}

		#endregion


		#region All paths

		/*You are given a binary tree in which each node contains a value. Design an algorithm 
		 * to print all paths which sum up to that value. Note that it can be any path in the
		 * tree - it does not have to start at the root.
		 */

		public static void AllPathsTest()
		{
			Node root = BinaryTree.RandomBinaryTree(new Random(10), 6, 0);
			T.PringBinaryTree(root);
			FindSum(root, 5, new List<int>(), 0);
		}

		public static void FindSum(Node root, int sum, List<int> buffer, int level)
		{
			if (root == null) return;

			int tmp = sum;

			buffer.Add(root.Value);
			for (int i = level; i > -1; i--)
			{
				tmp -= buffer[i];
				if (tmp == 0)
					Print(buffer, i, level);
			}

			List<int> c1 = new List<int>(buffer);
			List<int> c2 = new List<int>(buffer);
			FindSum(root.Left, sum, c1, level + 1);
			FindSum(root.Right, sum, c2, level + 1);
		}

		private static void Print(List<int> buffer, int n, int level)
		{
			for (int i = n; i <= level; i++)
			{
				T.W(buffer[i] + " ");
			}
			T.N("");
		}

		#endregion
	}
}

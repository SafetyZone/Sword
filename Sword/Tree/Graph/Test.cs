using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Tree.Graph
{
	public static class Test
	{
		public static void IsReachableTest()
		{
			Node start = new Node(0);
			start.AddNode(new Node(1));
			start.AddNode(new Node(2));
			start.AddNode(new Node(3));
			start.ReachableNodes[0].AddNode(new Node(4));
			start.ReachableNodes[1].AddNode(start.ReachableNodes[0].ReachableNodes[0]);
			start.ReachableNodes[1].AddNode(new Node(5));
			Node end = new Node(6);
			start.ReachableNodes[1].ReachableNodes[1].AddNode(end);

			T.N(IsReachable(start, end));
		}

		private static bool IsReachable(Node node, Node end)
		{
			node.State = VisitState.Visiting;
			T.N(node.Value);
			foreach (var r in node.ReachableNodes)
			{
				if (r.Value == end.Value || (r.State == VisitState.Unvisited && IsReachable(r, end)))
					return true;
			}
			node.State = VisitState.Visited;
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Tree.Graph
{
	public enum VisitState
	{
		Unvisited,
		Visiting,
		Visited
	}
	public class Node
	{
		private int _value;
		
		private VisitState _state;

		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public VisitState State
		{
			get { return _state; }
			set { _state = value; }
		}

		public Node(int value)
		{
			_value = value;
			ReachableNodes = new List<Node>();
			_state = VisitState.Unvisited;
		}

		public List<Node> ReachableNodes;

		public void AddNode(Node node)
		{
			ReachableNodes.Add(node);
		}
	}
}

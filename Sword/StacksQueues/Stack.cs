using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sword.LinkedList;

namespace Sword.StacksQueues
{
	public class Stack
	{
		Node top;

		public bool isEmpty()
		{
			return top == null;
		}

		public int pop()
		{
			if (top != null)
			{
				int data = top.data;
				top = top.next;
				return data;
			}
			return -1;
		}

		public void push(int data)
		{
			if (top == null)
				top = new Node(data);
			else
			{
				top.next = new Node(data);
				top = top.next;
			}
		}
	}
}

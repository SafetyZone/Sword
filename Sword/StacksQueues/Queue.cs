using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sword.LinkedList;

namespace Sword.StacksQueues
{
	public class Queue
	{
		Node first, last;
		
		public Queue()
		{
		}

		public void enqueue(int data)
		{
			if (first == null)
			{
				first = new Node(data);

			}
		}

		public int dequeue()
		{
			return 0;
		}
	}
}

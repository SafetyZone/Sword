using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.StacksQueues
{
	public class ArrayStack
	{
		private int[] stack;
		private int[] stackPointers;

		public ArrayStack(int stackSize)
		{
			stack = new int[stackSize * 3];
			stackPointers = new int[] { 0, 0, 0 };
		}

		public void push(int index, int val)
		{
			switch (index)
			{
				case 0:
					if (stack.Length / 2 - stackPointers[1] / 2 > stackPointers[index])//
						stack[stackPointers[index]++] = val;
					else throw new Exception("stack overflow");
					break;
				case 1:
					//check left right stack pointers intersactions
					// new position
					int realindex = stack.Length / 2 - stackPointers[1] / 2 * (-(stackPointers[1] + 1) % 2);

					if (stackPointers[0] < realindex && stackPointers[2] > realindex)
					{
						stack[realindex] = val;
						++stackPointers[index];
					}
					else throw new Exception("stack overflow");

					break;
				case 2:
					if (stack.Length / 2 + stackPointers[1] / 2 > stackPointers[index])//
						stack[stackPointers[index]++] = val;
					else
						throw new Exception("stack overflow");
					break;
			}
		}
	}
}

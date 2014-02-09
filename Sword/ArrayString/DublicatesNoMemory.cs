using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.ArrayString
{

	public class removeDuplicates
	{

		public static void Test()
		{
			char[] c = new char[] { 'a', 'b', 'c', 'd' };
			dublicatesNoMemory(c);
		}


		public static void dublicatesNoMemory(char[] str)
		{
			if (str == null) return;
			int len = str.Length;
			if (len < 2) return;

			int tail = 1;

			for (int i = 1; i < len; ++i)
			{
				int j;
				for (j = 0; j < tail; ++j)
				{
					if (str[i] == str[j]) break;
				}
				if (j == tail)
				{
					str[tail] = str[i];
					++tail;
				}
			}
			str[tail] = (char)0;
		}


	}
}

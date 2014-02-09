using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.ArrayString
{
	public static class ReplaceSpace
	{
		public static char[] Replace(char[] intString)
		{
			int spaceCnt = 0;
			for (int i = 0; i < intString.Length; i++)
				if (intString[i] == ' ') ++spaceCnt;

			char[] outString;
			if (spaceCnt > 0)
			{
				outString = new char[intString.Length + spaceCnt * 2];
				int newPosition = outString.Length - 1;
				for (int i = intString.Length - 1; i >= 0; i--)
				{
					if (intString[i] == ' ')
					{
						outString[newPosition - 2] = '%';
						outString[newPosition - 1] = '2';
						outString[newPosition] = '0';
						newPosition -= 3;
					}
					else
					{
						outString[newPosition--] = intString[i];
					}
				}
			}
			else
				outString = intString;

			return outString;
		}
	}
}

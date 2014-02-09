using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.ArrayString
{
	public static class Anagram
	{

		public static bool anagram(string a, string b)
		{
			if (a.Length != b.Length) return false;
			int[] letters = new int[256];

			int aUnqieChars = 0;
			foreach (char c in a)
			{
				if (letters[c] == 0) ++aUnqieChars;
				++letters[c];
			}
			
			for (int i = 0; i < b.Length; i++)
			{
				if (letters[b[i]] == 0) return false;
				--letters[b[i]];
				if (letters[b[i]] == 0) --aUnqieChars;
				if (aUnqieChars == 0)
					return i == b.Length - 1;
			}

			return false;
		}
	}
}

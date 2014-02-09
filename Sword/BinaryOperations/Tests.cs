using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.BinaryOperations
{
	public static class Tests
	{
		#region 5.1
		/*
		 * You are given two 32-bit numbers, N and M, and two bit positions,
		 * i and j. Write a method to set all bits between i and j in N equal
		 * to M (e.g., M becomes a substring of N located at i and starting at j).
		 * EXAMPLE:
		 * Input: N = 10000000000, M = 10101, i = 2, j = 6
		 * Output: N = 10001010100
		 */

		public static void Test51()
		{
			T.N(updateBits("10000000000", "10101", 2, 6).Equals("10001010100"));
			T.N(updateBits("10000000011", "0", 0, 0).Equals("10000000011"));
			T.N(updateBits("10000000011", "0", 1, 2).Equals("10000000001"));
			T.N(updateBits("10000001011", "10101111", 3, 9).Equals("10101111011"));
		}

		private static string updateBits(string n, string m, byte i, byte j)
		{
			UInt32 N = Convert.ToUInt32(n, 2);
			UInt32 M = Convert.ToUInt32(m, 2);
			UInt32 tmpN = ~(UInt32)0 << j;
			tmpN = tmpN | (UInt32)((1 << i) - 1);
			UInt32 r = N & tmpN | M << i;
			T.N(Convert.ToString(r, 2));
			return Convert.ToString(r, 2);
		}
		
		#endregion

		#region 5.2

		//public static void Test52()
		//{
		//    decimal d = 10;

		//    while()

		//}

		#endregion
	}
}

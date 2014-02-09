using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.ArrayString
{
	public static class RotateMatrix
	{
		public static void TestRotate()
		{
			//int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
			int[,] matrix = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
			var ret = rotate(matrix, 5);

			printMatrix(ret, 5);
		}

		public static void TestZero()
		{
			int[,] matrix = new int[,] { { 1, 2, 0, 4, 5 }, { 6, 7, 8, 9, 10 }, { 0, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
			var ret = zero(matrix, 5, 5);

			printMatrix(ret, 5);
		}

		private static void printMatrix(int[,] ret, int n)
		{
			for (int x = 0; x < n; ++x)
			{
				for (int y = 0; y < n; ++y)
				{
					Console.Write(ret[x, y].ToString("00 "));
				}
				Console.WriteLine();
			}
		}

		public static int[,] rotate(int[,] matrix, int n_)
		{
			//int[,] ret = new int[n, n];
			int n = n_ - 1;
			for (int x = 0; x <= n_ / 2; ++x)
			{
				for (int y = 0; y < n_ / 2; ++y)
				{
					int x_ = y;
					int y_ = n - x;
					int tmp = matrix[y, n - x]; //x=y; y=n-x;
					matrix[y, n - x] = matrix[x, y]; //3rd

					int tmp2 = matrix[n - x, n - y];//x=n-x; y=n-y;
					matrix[n - x, n - y] = tmp;

					tmp = matrix[n - y, x];
					matrix[n - y, x] = tmp2;

					matrix[x, y] = tmp;

				}
			}

			return matrix;
		}

		public static int[,] zero(int[,] matrix, int m, int n)
		{
			int[] row = new int[m];
			int[] col = new int[n];

			for (int y = 0; y < n; ++y)
			{
				for (int x = 0; x < m; ++x)
				{
					if (matrix[y, x] == 0)
					{
						col[y] = row[x] = 1;
					}
				}
			}

			for (int y = 0; y < n; ++y)
			{
				for (int x = 0; x < m; ++x)
				{
					if (row[y] == 1 || col[x] == 1)
						matrix[y, x] = 0;
				}
			}

			return matrix;
		}
	}
}
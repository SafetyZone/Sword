using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sword.Sorting.Exchange;
using Sword.Sorting;
using Sword.Sorting.Insertion;
using Sword.ArrayString;

namespace Sword
{
	class Program
	{
		static Random rnd = new Random();

		static int[] Everage { get { return new int[] { 5, 8, 1, 6, 9, 2, 4, 0, 3 }; } }
		static int[] Worst { get { return new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }; } }
		static int[] Best { get { return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; } }
		static int[] qSortKorman { get { return new int[] { 2, 3, 7, 4, 1, 5, 6, 8 }; } }

		static void Main(string[] args)
		{
            Sorting.Merge.Test91.Test1();
            return;
            //QSortStack qss = new QSortStack();
            //T.PrintArray(qss.Sort(Everage));

			Sword.BinaryOperations.Tests.Test51();
			Sword.Tree.Graph.Test.IsReachableTest();
			Tree.BT.Tests.AllPathsTest();
			Tree.BT.Tests.SubTreeTest();
			Tree.BT.Tests.BTCommonAncestorImprovedTest();
			Tree.BT.Tests.BTCommonAncestorCoversTest();
			Tree.BT.Tests.BSTCommonAncestorParentTest();
			Tree.BT.Tests.BSTCommonAncestorTest();
			Tree.BT.Tests.InOrderSuccessorTest();
			Tree.BT.Tests.LinkedListOfNodesTest();
			Tree.BT.Tests.CreateMinHFromsortedArray();
			Tree.BT.Tests.BalancedBT();
			Sword.Tree.BT.BTTest.Test1();
			LinkedList.TestNodes.TestFindNthFromToEndRecursion();
			LinkedList.TestNodes.TestFindNthFromToEnd();
			LinkedList.TestNodes.TestRemoveDublicatesNoHT();
			LinkedList.TestNodes.TestRemoveDublicatesHT();

			//TimeTestArray(new Bubble());
			//TimeTestArray(new Coctail());
			//TimeTestArray(new Insertion());

			//EVBTestArray(new Bubble());
			//EVBTestArray(new Coctail());
			//EVBTestArray(new Insertion());

			RotateMatrix.TestZero();

			RotateMatrix.TestRotate();

			System.Diagnostics.Debug.WriteLine(ReplaceSpace.Replace(new char[] { 'a', ' ', 'b' }));

			System.Diagnostics.Debug.WriteLine(Anagram.anagram("mama", "amam"));




			removeDuplicates.Test();

			new QSort().Sort(qSortKorman);

			BigMoveTest(new Bubble());
			BigMoveTest(new Coctail());
			BigMoveTest(new Insertion());

			T.N("done.");
			Console.ReadLine();
		}


		static void BigMoveTest(SortingAlg s)
		{
			T.N(s.Name);
			int[] r;
			r = s.Sort(GenerateArray(100000));
			T.N("Everage move:" + s.Move);
		}

		static void EVBTestArray(SortingAlg s)
		{
			T.N(s.Name);
			int[] r;
			r = s.Sort(Everage);
			T.N("Everage move:" + s.Move);
			CheckArray(r);
			r = s.Sort(Worst);
			T.N("Worst move:" + s.Move);
			CheckArray(r);
			r = s.Sort(Best);
			T.N("Best move:" + s.Move);
			CheckArray(r);
		}

		static void TimeTestArray(SortingAlg s)
		{
			int[] a, r;

			int loop = 1;
			T.N(s.Name);
			for (int order = 0; order < 4; order++)
			{
				T.W(string.Format("Power:{0,-5} = ", (int)Math.Pow(10, order)));
				DateTime dt = DateTime.Now;
				for (int i = 0; i < loop; i++)
				{
					a = GenerateArray((int)Math.Pow(10, order));
					r = s.Sort(a);
					CheckArray(r);
				};
				TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - dt.Ticks);
				T.N(string.Format("{0,-8}", (ts.Ticks / loop).ToString("00000000")));
			}
		}

		static bool CheckArray(int[] array)
		{
			for (int i = 0; i < array.Length - 2; i++)
			{
				if (array[i] > array[i + 1])
				{
					T.PrintArray(array);
					return true;
				}
			}
			return false;
		}

		static int[] GenerateArray(int size)
		{
			int[] ret = new int[size];
			for (int i = 0; i < size; i++)
			{
				ret[i] = rnd.Next(10);
			}
			return ret;
		}
	}
}

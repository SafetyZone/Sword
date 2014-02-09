using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting.Merge
{
    [TestClass]
    internal class Test91
    {
        [TestMethod]
        public static void Test1()
        {
            int[] a = new int[] { 220, 221, 222, 223, 424, 425, 426, 427, 428, 429, 0, 0, 0, 0, 0, 0 };
            int[] b = new int[] { 310, 311, 312, 313, 314, 315 };
            MergeAB(a, b, 10, 6);
            T.PrintArray(a);
        }

        /*
         [ , , , , , , , , , , , , , , , , , ]
         
         */

        static void MergeAB(int[] a, int[] b, int aL, int bL)
        {
            int k = aL + bL - 1;
            int i = aL - 1;
            int j = bL - 1;

            while (j >= 0 && i >= 0)
            {
                if (a[i] > b[j])
                {
                    a[k--] = a[i--];
                }
                else
                {
                    a[k--] = b[j--];
                }
            }

            while (j >= 0)
            {
                a[k--] = b[j--];
            }
        }
    }
}

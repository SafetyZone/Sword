using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Area
{
    [TestClass]
    public class MaximizingHistogram
    {
        public int from;
        public int to;
        public int height;

        public MaximizingHistogram()
        {
        }

        public MaximizingHistogram(int from, int to, int height)
        {
            this.from = from;
            this.to = to;
            this.height = height;
        }

        public int Area() { return (to - from + 1) * height; }

        public String toString() { return "(" + from + "," + to + "," + height + ")"; }


        public static MaximizingHistogram MaxHistRect(int[] histogram)
        {
            if (histogram == null) { return null; }

            Stack<int> stack = new Stack<int>();
            MaximizingHistogram res = new MaximizingHistogram(0, 0, 0);
            int i = 0;
            while ((i < histogram.Length) || (stack.Count != 0))
            {
                if ((stack.Count == 0) || ((i < histogram.Length) && (histogram[i] >= histogram[stack.Peek()]))) { stack.Push(i++); }
                else
                {
                    int cur = stack.Pop();
                    if (histogram[cur] * (i - cur) >= res.Area()) { res = new MaximizingHistogram(cur, i - 1, histogram[cur]); }
                }
            }

            return res;
        }

        #region tests
        [TestMethod]
        public void Test()
        {
            var hist = new[] { 1, 3, 5, 2, 4, 1, 3 };
            var res = MaximizingHistogram.MaxHistRect(hist);
            Assert.IsNotNull(res);
        }
        #endregion
    }
}

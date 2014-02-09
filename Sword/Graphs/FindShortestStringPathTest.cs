using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sword
{
    [TestClass]
    public class FindShortestStringPathTest
    {

        [TestMethod]
        public void SimpleTest()
        {
            string from = "aaa";
            string to = "fff";
            IEnumerable<string> dict = new List<string>()
            {
                "aba",
                                "adf",
                "dde",
                "dfe",
                "ffe",
                "fbc",
                "fcc",
                "ffc",
                "abc",
                "fbb",
                "adc",
                "ade",
                "bde"
            };

            var res = FindShortestStringPath.FindPath(from, to, dict);
            if (res != null)
            {
                foreach (var r in res)
                {
                    Console.Write(r);
                    Console.Write(">");
                }
            }
        }
    }
}

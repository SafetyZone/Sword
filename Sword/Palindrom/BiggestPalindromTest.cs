using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Palindrom
{
    [TestClass]
    public class BiggestPalindromTest
    {
        [TestMethod]
        public void NullIsPalindromTest()
        {
            Assert.IsFalse(BigestPalindrom.IsPalindrom(null));
        }

        [TestMethod]
        public void EmptyIsPalindromTest()
        {
            Assert.IsFalse(BigestPalindrom.IsPalindrom(string.Empty));
        }

        [TestMethod]
        public void x_IsPalindromTest()
        {
            Assert.IsTrue(BigestPalindrom.IsPalindrom("x"));
        }

        [TestMethod]
        public void aba_IsPalindromTest()
        {
            Assert.IsTrue(BigestPalindrom.IsPalindrom("aba"));
        }

        [TestMethod]
        public void abba_IsPalindromTest()
        {
            Assert.IsTrue(BigestPalindrom.IsPalindrom("abba"));
        }

        [TestMethod]
        public void absbaIsPalindromTest()
        {
            Assert.IsFalse(BigestPalindrom.IsPalindrom("abbax"));
        }
    }
}

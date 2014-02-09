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
        #region IsPalindrom

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

        #endregion

        #region Is part of the string is Palindrom

        [TestMethod]
        public void PartIsPalindromNullTest()
        {
            Assert.IsFalse(BigestPalindrom.IsPalindrom(null, 0, 0));
        }

        [TestMethod]
        public void PartIsPalindromATest()
        {
            Assert.IsFalse(BigestPalindrom.IsPalindrom("a", 0, 0));
        }

        [TestMethod]
        public void PartIsPalindromTwoLettersTest()
        {
            Assert.IsTrue(BigestPalindrom.IsPalindrom("aa", 0, 1));
        }

        [TestMethod]
        public void PartIsNotPalindromTwoLettersTest()
        {
            Assert.IsTrue(BigestPalindrom.IsPalindrom("ab", 0, 1));
        }

        [TestMethod]
        public void IsPalindromTest()
        {
            Assert.IsTrue(BigestPalindrom.IsPalindrom("abbax", 0, 3));
        }

        #endregion


    }
}

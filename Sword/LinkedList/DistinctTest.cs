using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sword.LinkedList
{
    [TestClass]
    public class DistinctTest
    {

        [TestMethod]
        public void TestDistinctValues1()
        {
            Node Head = CreateLinkedList(new[] { 1, 2, 2, 2, 4, 5, 6, 6 });
            Head = DistinctValues(Head);
            Assert.IsTrue(Node.Compare(Head, CreateLinkedList(new[] { 1, 4, 5 })));
        }

        [TestMethod]
        public void TestDistinctValues2()
        {
            Node Head = CreateLinkedList(new[] { 1, 1, 2, 2, 2, 4, 5, 6, 6 });
            Head = DistinctValues(Head);
            Assert.IsTrue(
                Node.Compare(
                    Head,
                    CreateLinkedList(new[] { 4, 5 })));
        }

        [TestMethod]
        public void TestDistinctValues3()
        {
            Node Head = CreateLinkedList(new[] { 1 });
            Head = DistinctValues(Head);
            Assert.IsTrue(
                Node.Compare(
                    Head,
                    CreateLinkedList(new[] { 1 })));
        }

        [TestMethod]
        public void TestDistinctValues4()
        {
            Node Head = CreateLinkedList(new[] { 1, 1 });
            Head = DistinctValues(Head);
            Assert.IsNull(Head);
        }

        [TestMethod]
        public void TestDistinctValues5()
        {
            Node Head = CreateLinkedList(new[] { 1, 1, 2, 2, 2, 2 });
            Head = DistinctValues(Head);
            Assert.IsNull(Head);
        }

        private Node DistinctValues(Node Head)
        {
            Node previous = null;
            Node n = Head;
            Node newHead = null;
            while (n != null)
            {
                int count = 1;
                while (n.next != null && n.data == n.next.data)
                {
                    ++count;
                    n = n.next;
                }
                if (count == 1)
                {
                    if (previous != null)
                    {
                        previous.next = n;
                    }
                    else
                    {
                        newHead = n;
                    }
                    previous = n;

                }
                n = n.next;
            }
            if (previous != null)
            {
                previous.next = null;
            }

            previous = newHead;
            while (previous != null)
            {
                Console.Write(previous.data);
                Console.Write(" ");
                previous = previous.next;
            }
            return newHead;
        }

        public static Node CreateLinkedList(int[] data)
        {
            Node head;
            Node n = new Node(0);
            head = n;
            foreach (int d in data)
            {
                n.next = new Node(d);
                n = n.next;
            }
            return head.next;
        }
    }
}

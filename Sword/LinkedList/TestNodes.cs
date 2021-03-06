﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Sword.LinkedList
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestNodes
    {
        public static void TestRemoveDublicatesHT()
        {
            Node Head = CreateLinkedList(new int[] { 1, 2, 3, 2, 4, 5, 6, 2, 2 });
            PrintLinkedList(Head);
            Node newhead = Node.RemoveDublicatesHT(Head);
            PrintLinkedList(newhead);
        }

        public static void TestRemoveDublicatesNoHT()
        {
            //			Node Head = CreateLinkedList(new int[] { 1, 2, 1, 2, 3 });
            Node Head = CreateLinkedList(new int[] { 1, 2, 3, 2, 4, 5, 6, 2, 2 });
            PrintLinkedList(Head);
            Node newhead = Node.RemoveDublicatesNoHT(Head);
            PrintLinkedList(newhead);
        }

        public static void TestFindNthFromToEnd()
        {
            Node Head = CreateLinkedList(new int[] { 1, 2, 3, 2, 4, 5, 6, 10, 8 });
            PrintLinkedList(Head);
            Node newhead = Node.FindNthFromToEnd(Head, 8);
            if (newhead != null)
                Debug.WriteLine(newhead.data);

        }

        internal static void TestFindNthFromToEndRecursion()
        {
            Node Head = CreateLinkedList(new int[] { 1, 2, 3, 2, 4, 5, 6, 10, 8 });
            PrintLinkedList(Head);
            Node newhead = Node.FindNthFromToEndRecursion(Head, 8);
            if (newhead != null)
                Debug.WriteLine(newhead.data);
        }

        public static void PrintLinkedList(Node head)
        {
            Node n = head;
            while (n != null)
            {
                Debug.Write(n.data.ToString("00-"));
                n = n.next;
            }
            Debug.WriteLine("");
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

        #region Reverse Linked List

        [TestMethod]
        public void ReversTest()
        {
            Node Head = CreateLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Node newHead = Node.Reverse(Head);

            Assert.IsTrue(Node.Compare(newHead, CreateLinkedList(new int[] { 7, 6, 5, 4, 3, 2, 1 })));
        }

        #endregion
    }
}
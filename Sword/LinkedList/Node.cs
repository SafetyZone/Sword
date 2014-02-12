using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Sword.LinkedList
{
    public class Node
    {
        public Node next = null;

        public int data;

        public Node(int data)
        {
            this.data = data;
        }

        public void Append(int d)
        {
            Node end = this.next;
            while (end.next != null)
                end = end.next;
            end.next = new Node(d);
        }

        public static bool Compare(Node a, Node b)
        {
            if (a == null && b == null)
            {
                return false;
            }

            while (a != null && b != null)
            {
                if (a.data != b.data)
                    return false;
                a = a.next;
                b = b.next;
            }

            return true;
        }
        public static Node Delete(Node head, int data)
        {
            Node n = head;
            if (n.data == data)
                return head.next;
            while (n.next != null)
            {
                if (n.data == data)
                {
                    n.next = n.next.next;
                    return head;
                }
                n = n.next;
            }
            return head;
        }

        public static Node RemoveDublicatesHT(Node head)
        {
            Hashtable ht = new Hashtable();
            Node n = head;
            Node previos = n;
            while (n != null)
            {
                if (ht.Contains(n.data))
                {
                    previos.next = n.next;
                    n = previos;
                }
                else
                {
                    ht.Add(n.data, n.data);
                }
                previos = n;
                n = n.next;
            }
            return head;
        }

        public static Node RemoveDublicatesNoHT(Node head)
        {
            Node n = head;
            Node prev = n;
            while (n != null)
            {
                Node search = head;
                while (search != n)
                {
                    if (search.data == n.data)
                    {
                        prev.next = n.next;
                        n = prev;
                    }
                    search = search.next;
                }
                prev = n;
                n = n.next;
            }
            return head;
        }

        public static Node FindNthFromToEnd(Node head, int Nth)
        {
            Node n = head;
            int pos = 0;
            while (n != null && ++pos <= Nth)
                n = n.next;

            if (n == null)
                return null; // size of the node list is less than N

            Node ret = head;
            while (n.next != null)
            {
                n = n.next;
                ret = ret.next;
            }
            return ret;
        }

        public static Node FindNthFromToEndRecursion(Node head, int nth)
        {
            int depth = 0;
            return findNthFromToEndRecursion(head, nth, ref depth);
        }

        private static Node findNthFromToEndRecursion(Node head, int nth, ref int depth)
        {
            if (head == null)
                return null;
            int lvl = ++depth;
            Node ret = findNthFromToEndRecursion(head.next, nth, ref depth);
            if (depth - nth == lvl)
                return head;
            else
                return ret;
        }

        private static Node AddLInkedList(Node l1, Node l2)
        {
            Node ret = new Node(0);
            int digit = 0;

            while (l1 != null || l2 != null)
            {
                int summ = l1.data + l2.data + digit;
                digit = (summ >= 10) ? 1 : 0;
                summ = Math.Abs(summ - 10);
                if (ret == null)
                    ret = new Node(summ);
                else
                    ret.next = new Node(summ);
                l1 = l1.next;
                l2 = l2.next;
            }

            return ret;
        }
    }
}

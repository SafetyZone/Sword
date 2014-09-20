using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera.Alg
{
    public class QuickUnionUF
    {
        private int[] id;

        public QuickUnionUF(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }

        public bool IsConnected(int p, int q)
        {
            return root(p) == root(q);
        }

        public void Union(int p, int q)
        {
            int rp = root(p);
            int rq = root(q);

            id[p] = rq;
        }

        private int root(int i)
        {
            while (i != id[i]) i = id[i];
            return i;
        }
    }
}

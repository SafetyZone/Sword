using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting
{
    public abstract class SortingAlg
    {
        protected decimal _move = 0;
        public decimal Move { get { return _move; } }
        public abstract int[] Sort(int[] array);
        public abstract string Name { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting.Insertion
{
    public class Insertion : SortingAlg
    {
        public override int[] Sort(int[] array)
        {
            _move = 0;
            int j, tmp;
            for (int i = 0; i < array.Length; i++)
            {
                tmp = array[i];
                for (j = i - 1; j >= 0 && array[j] > tmp; j--)
                {
                    array[j + 1] = array[j]; _move++;
                }
                array[j + 1] = tmp;
            }

            return array;
        }

        public override string Name { get { return "Insertion"; } }
    }
}

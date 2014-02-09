using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting.Exchange
{
    /// <summary>
    /// Worst O(n^2)
    /// Best O(n)
    /// Average O(n^2)
    /// </summary>
    public class Bubble : SortingAlg
    {
        public override int[] Sort(int[] array)
        {
            _move = 0;

            bool t = true;

            while (t)
            {
                t = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        array[i] = array[i] ^ array[i + 1];
                        array[i + 1] = array[i] ^ array[i + 1];
                        array[i] = array[i] ^ array[i + 1];
                        _move++;
                        t = true;// was atlist one swaping;
                    }
                }
            }

            return array;
        }

        public override string Name { get { return "Bubble"; } }
    }

    
}

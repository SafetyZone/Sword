using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Sorting.Exchange
{
    public class Coctail : SortingAlg
    {

        public override string Name { get { return "Coctail"; } }

        public override int[] Sort(int[] array)
        {
            _move = 0;

            bool swaped = true;
            int begin = 0;
            int end = array.Length - 1;
            while (swaped)
            {
                swaped = false;
                for (int i = begin++; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        array[i] = array[i] ^ array[i + 1]; array[i + 1] = array[i] ^ array[i + 1]; array[i] = array[i] ^ array[i + 1];
                        _move++;
                        swaped = true;
                    }
                }

                if (!swaped) break;

                for (int j = end--; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        array[j] = array[j] ^ array[j - 1]; array[j - 1] = array[j] ^ array[j - 1]; array[j] = array[j] ^ array[j - 1];
                        _move++; 
                        swaped = true;
                    }
                }


            }
            return array;
        }

    }
}

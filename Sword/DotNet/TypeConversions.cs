using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.DotNet
{

    internal class TypeConversions
    {
        public void F()
        {
            int a = 0;

            if (a == null)
            {
                System.Diagnostics.Debug.Write("null");
            }
            else
            {
                System.Diagnostics.Debug.Write("not null");
            }
        }
    }
}

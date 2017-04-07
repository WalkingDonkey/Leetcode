using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Algorithms
{
    public class Mathematics
    {
        // sum = (x + 1) * x / 2
        // x = (-1 + sqrt(8 * n + 1)) / 2
        public int ArrangeCoins(int n)
        {
            return (int)((Math.Sqrt(1 + 8.0 * n) - 1) / 2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library
{
    public class PositionConverter : IPositionConverter
    {
        public (int, int) Convert(string position)
        {
            int x = position[0] - 'a' + 1;
            int y = position[1] - '1' + 1;
            return (x, y);
        }
    }
}

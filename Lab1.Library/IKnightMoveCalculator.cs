using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library
{
    public interface IKnightMoveCalculator
    {
        string GetMinimumMoves((int x1, int y1) start, (int x2, int y2) end);

    }
}

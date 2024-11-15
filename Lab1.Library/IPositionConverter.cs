using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library
{
    public interface IPositionConverter
    {
        (int, int) Convert(string position);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Solution
    {

        // Проверка корректности хода коня
        public static bool IsMoveValid(int mx, int my, int nx, int ny)
        {
            if (mx < 0 || mx > 7 || my < 0 || my > 7) return false;
            if (nx < 0 || nx > 7 || ny < 0 || ny > 7) return false;

            return (Math.Abs(mx - nx) == 2 && Math.Abs(my - ny) == 1) ||
                   (Math.Abs(mx - nx) == 1 && Math.Abs(my - ny) == 2);
        }
    }
}

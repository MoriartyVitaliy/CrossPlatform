namespace Lab1.Library
{
    public class KnightMoveCalculator : IKnightMoveCalculator
    {
        private readonly int[][] moves = {
            new int[] { 2, 1 }, new int[] { 2, -1 },
            new int[] { -2, 1 }, new int[] { -2, -1 },
            new int[] { 1, 2 }, new int[] { 1, -2 },
            new int[] { -1, 2 }, new int[] { -1, -2 }
            };

        public string GetMinimumMoves((int x1, int y1) start, (int x2, int y2) end)
        {
            if (CanReachInOneMove(start, end)) return "1";
            if (CanReachInTwoMoves(start, end)) return "2";
            return "NO";
        }

        private bool CanReachInOneMove((int x, int y) start, (int x, int y) end)
        {
            foreach (var move in moves)
            {
                if (start.x + move[0] == end.x && start.y + move[1] == end.y)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanReachInTwoMoves((int x, int y) start, (int x, int y) end)
        {
            foreach (var move in moves)
            {
                int nx = start.x + move[0];
                int ny = start.y + move[1];
                if (CanReachInOneMove((nx, ny), end))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

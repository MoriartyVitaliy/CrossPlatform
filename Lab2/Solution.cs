using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Solution
    {
        public static int MinValue(int n, Agent[] agents, int[] minRisks)
        {
            if (n > 2)
            {
                minRisks[2] = agents[1].Risk + agents[2].Risk;
            }
            if (n > 3)
            {
                minRisks[3] = agents[1].Risk + agents[3].Risk;
            }
            for (int i = 4; i < n; i++)
            {
                minRisks[i] = Math.Min(minRisks[i - 2] + agents[i].Risk, minRisks[i - 3] + agents[i - 1].Risk + agents[i].Risk);
            }

            return minRisks[n - 1];
        }
    }
}

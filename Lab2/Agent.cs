using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Agent
    {
        public Agent(int age, int risk)
        {
            Age = age;
            Risk = risk;
        }
        public int Age { get; set; }
        public int Risk { get; set; }
    }
}

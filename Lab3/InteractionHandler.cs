using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class InteractionHandler : IInteractionHandler
    {
        public bool CanInteract(int i, int j, bool[,] destructionMatrix, List<int> state)
        {
            return (i == j && state[i] >= 2 && destructionMatrix[i, i]) ||
                   (i != j && state[i] > 0 && state[j] > 0 && (destructionMatrix[i, j] || destructionMatrix[j, i]));
        }

        public List<int> HandleInteraction(int i, int j, List<int> currentState)
        {
            var nextState = new List<int>(currentState);
            if (i == j)
            {
                nextState[i]--;
            }
            else
            {
                nextState[j]--;
            }
            return nextState;
        }
    }
}

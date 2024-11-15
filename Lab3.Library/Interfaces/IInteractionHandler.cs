using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Library
{
    public interface IInteractionHandler
    {
        bool CanInteract(int i, int j, bool[,] destructionMatrix, List<int> state);
        List<int> HandleInteraction(int i, int j, List<int> currentState);
    }
}

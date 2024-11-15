

namespace Lab3.Library
{
    class Simulation
    {
        private readonly IInteractionHandler _interactionHandler;

        public Simulation(IInteractionHandler interactionHandler)
        {
            _interactionHandler = interactionHandler;
        }

        public HashSet<List<int>> CalculateFinalStates(List<int> initialState, bool[,] destructionMatrix, int n)
        {
            HashSet<List<int>> allStates = new HashSet<List<int>>(new ListComparer());
            HashSet<List<int>> finalStates = new HashSet<List<int>>(new ListComparer());
            Queue<List<int>> queue = new Queue<List<int>>();
        
            allStates.Add(new List<int>(initialState));
            queue.Enqueue(new List<int>(initialState));

            while (queue.Count > 0)
            {
                List<int> currentState = queue.Dequeue();
                bool isFinal = true;

                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        if (_interactionHandler.CanInteract(i, j, destructionMatrix, currentState))
                        {
                            var nextState = _interactionHandler.HandleInteraction(i, j, currentState);
                            isFinal = false;
                            if (allStates.Add(nextState))
                            {
                                queue.Enqueue(nextState);
                            }
                        }
                    }
                }

                if (isFinal)
                {
                    finalStates.Add(currentState);
                }
            }

            return finalStates;
        }
    }

}

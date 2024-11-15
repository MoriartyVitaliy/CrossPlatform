namespace Lab3.Library
{

    public static class ParticleProcessor
    {
        public static HashSet<List<int>> ProcessParticles(int n, List<int> particles, bool[,] destructionMatrix)
        {
            HashSet<List<int>> allStates = new HashSet<List<int>>(new ListComparer());
            Queue<List<int>> queue = new Queue<List<int>>();
            allStates.Add(new List<int>(particles));
            queue.Enqueue(new List<int>(particles));

            HashSet<List<int>> finalStates = new HashSet<List<int>>(new ListComparer());

            while (queue.Count > 0)
            {
                List<int> current = queue.Dequeue();
                bool isFinal = true;

                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        if (i == j && current[i] >= 2 && destructionMatrix[i, i])
                        {
                            var next = new List<int>(current);
                            next[i]--;
                            isFinal = false;
                            EnqueueState(next, allStates, queue);
                        }
                        else if (i != j)
                        {
                            ProcessPair(i, j, current, destructionMatrix, allStates, queue, ref isFinal);
                        }
                    }
                }

                if (isFinal)
                {
                    finalStates.Add(current);
                }
            }

            return finalStates;
        }

        private static void ProcessPair(int i, int j, List<int> current, bool[,] destructionMatrix, HashSet<List<int>> allStates, Queue<List<int>> queue, ref bool isFinal)
        {
            if (current[i] > 0 && current[j] > 0)
            {
                if (destructionMatrix[i, j])
                {
                    var next = new List<int>(current);
                    next[j]--;
                    isFinal = false;
                    EnqueueState(next, allStates, queue);
                }
                if (destructionMatrix[j, i])
                {
                    var next = new List<int>(current);
                    next[i]--;
                    isFinal = false;
                    EnqueueState(next, allStates, queue);
                }
            }
        }

        private static void EnqueueState(List<int> state, HashSet<List<int>> allStates, Queue<List<int>> queue)
        {
            if (!allStates.Contains(state))
            {
                allStates.Add(state);
                queue.Enqueue(state);
            }
        }
    }
}

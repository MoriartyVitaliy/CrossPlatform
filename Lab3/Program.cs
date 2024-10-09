namespace Lab3
{

    class Program
    {
        static void Main()
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");

            // Чтение входных данных
            var (n, particles, destructionMatrix) = InputReader.ReadInput(inputFilePath);

            // Поиск финальных состояний
            var finalStates = ParticleProcessor.ProcessParticles(n, particles, destructionMatrix);

            // Запись выходных данных
            OutputWriter.WriteOutput(outputFilePath, finalStates);
        }
    }

}

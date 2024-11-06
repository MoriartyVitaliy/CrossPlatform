namespace Lab3
{

    public class Program
    {
        public static void Main(string inputFile, string outputFile)
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

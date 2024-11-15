using Lab3.Library;

namespace Lab3.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = args.Length > 0 ? args[0] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt");
            string outputFilePath = args.Length > 1 ? args[1] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt");

            var (n, particles, destructionMatrix) = Utils.ReadInput(inputFilePath);

            var finalStates = ParticleProcessor.ProcessParticles(n, particles, destructionMatrix);

            Utils.WriteOutput(outputFilePath, finalStates);
        }
    }
}

using Lab3.Library;

namespace LabsLibrary
{
    public class Lab3Runner : ILabsRunner
    {
        public void Execute(string inputFilePath, string outputFilePath)
        {
            var (n, particles, destructionMatrix) = Utils.ReadInput(inputFilePath);

            var finalStates = ParticleProcessor.ProcessParticles(n, particles, destructionMatrix);

            Utils.WriteOutput(outputFilePath, finalStates);
        }
    }
    
}

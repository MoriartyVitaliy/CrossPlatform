using Lab2.Library;

namespace Lab2.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\INPUT.txt");
            string outputPath = args.Length > 1 ? args[1] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\OUTPUT.txt");

            try
            {
                var input = Utils.ReadInput(inputPath);
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input file is empty or unreadable.");
                    return;
                }

                if (!Utils.FillArray(input, out int n, out Agent[] agents))
                {
                    Console.WriteLine("Error: Failed to fill agent data.");
                    return;
                }

                int[] minRisks = new int[n];
                minRisks[1] = agents[1].Risk; // Initialize second agent's risk

                int result = Solution.MinValue(n, agents, minRisks);

                // Writing to output file
                if (Utils.WriteOutput(outputPath, result))
                {
                    Console.WriteLine("File created successfully with the result.");
                }
                else
                {
                    Console.WriteLine("Error: Failed to write to output file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

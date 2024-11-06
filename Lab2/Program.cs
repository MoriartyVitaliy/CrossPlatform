using System.Threading.Channels;

namespace Lab2
{
    public class Program
    {
        public static void Main(string inputFile, string outputFile)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string input = Utils.ReadInput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt"));

            if (!Utils.FillArray(input, out int n, out Agent[] agents))
            {
                return;
            }

            int[] minRisks = new int[n];
            minRisks[1] = agents[1].Risk;

            Solution.MinValue(n, agents, minRisks);
            Utils.EmptyFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"));
            if(Utils.WriteOutput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"), minRisks[n - 1]))   
                Console.WriteLine("File created");
            else
                Console.WriteLine("Error");

        }
    }
}

using System.Threading.Channels;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string input = Utils.ReadInput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt"));

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            if (!Utils.FillArray(input, out int n, out Agent[] agents))
            {
                return;
            }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

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

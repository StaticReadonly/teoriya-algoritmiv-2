using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    public class Tests5_10
    {
        private readonly ITestOutputHelper output;

        public Tests5_10(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_5_10.txt", "results\\IA-31_Brigade1_01_5-10-3.txt", 3)]
        [InlineData("task_02_data_examples\\input_5_10.txt", "results\\IA-31_Brigade1_01_5-10-4.txt", 4)]
        public async Task Test(string inputFile, string outputFile, int id)
        {
            FileHelper helper = new FileHelper();
            Stopwatch sw = Stopwatch.StartNew();

            var results = await helper.ReadResults(inputFile, id);
            await helper.WriteUserResultsInFile(outputFile, results, id);
            sw.Stop();

            output.WriteLine("Elapsed: {0}", sw.Elapsed);
        }
    }
}
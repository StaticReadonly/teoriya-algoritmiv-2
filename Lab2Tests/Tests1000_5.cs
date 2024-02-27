using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    public class Tests1000_5
    {
        private readonly ITestOutputHelper output;

        public Tests1000_5(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_1000_5.txt", "results\\IA-31_Brigade1_01_1000-5-289.txt", 289)]
        [InlineData("task_02_data_examples\\input_1000_5.txt", "results\\IA-31_Brigade1_01_1000-5-356.txt", 356)]
        [InlineData("task_02_data_examples\\input_1000_5.txt", "results\\IA-31_Brigade1_01_1000-5-674.txt", 674)]
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
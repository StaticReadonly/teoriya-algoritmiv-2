using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    public class Tests5_5
    {
        private readonly ITestOutputHelper output;

        public Tests5_5(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_5_5.txt", "results\\IA-31_Brigade1_01_5-5-4.txt", 4)]
        [InlineData("task_02_data_examples\\input_5_5.txt", "results\\IA-31_Brigade1_01_5-5-5.txt", 5)]
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
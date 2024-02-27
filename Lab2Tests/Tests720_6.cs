using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    public class Tests720_6
    {
        private readonly ITestOutputHelper output;

        public Tests720_6(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_720_6.txt", "results\\IA-31_Brigade1_01_720-6-1.txt", 1)]
        [InlineData("task_02_data_examples\\input_720_6.txt", "results\\IA-31_Brigade1_01_720-6-100.txt", 100)]
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
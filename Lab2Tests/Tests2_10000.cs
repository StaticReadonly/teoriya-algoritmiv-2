using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    public class Tests2_10000
    {
        private readonly ITestOutputHelper output;

        public Tests2_10000(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_2_10000.txt", "results\\IA-31_Brigade1_01_2-10000-1.txt", 1)]
        [InlineData("task_02_data_examples\\input_2_10000.txt", "results\\IA-31_Brigade1_01_2-10000-2.txt", 2)]
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
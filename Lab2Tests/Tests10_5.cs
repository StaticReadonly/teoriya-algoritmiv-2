using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    
    public class Tests10_5
    {
        private readonly ITestOutputHelper output;

        public Tests10_5(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_10_5.txt", "results\\IA-31_Brigade1_01_10-5-10.txt", 10)]
        [InlineData("task_02_data_examples\\input_10_5.txt", "results\\IA-31_Brigade1_01_10-5-6.txt", 6)]
        [InlineData("task_02_data_examples\\input_10_5.txt", "results\\IA-31_Brigade1_01_10-5-9.txt", 9)]
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

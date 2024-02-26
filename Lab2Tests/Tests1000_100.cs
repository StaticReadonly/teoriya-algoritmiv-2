using Lab2;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Lab2Tests
{
    public class Tests1000_100
    {
        private readonly ITestOutputHelper output;

        public Tests1000_100(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-206.txt", 206)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-210.txt", 210)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-231.txt", 231)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-306.txt", 306)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-430.txt", 430)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-552.txt", 552)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-572.txt", 572)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-719.txt", 719)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-847.txt", 847)]
        [InlineData("task_02_data_examples\\input_1000_100.txt", "results\\IA-31_Brigade1_01_1000-100-95.txt", 95)]
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

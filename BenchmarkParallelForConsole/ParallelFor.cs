using BenchmarkParallelForConsole.Service;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkParallelForConsole.Helper;

namespace BenchmarkParallelForConsole
{
    [IterationCount(1)]
    [SimpleJob(RunStrategy.ColdStart)]
    public class ParallelFor
    {
        private const int MaxDegreeOfParallelism = 2;
        private const int NumberOfFilesToProcess = 10; 
        private const int BatchSaveSize = 250;

        [Benchmark]
        public void ForLoop()
        {
            Console.WriteLine("Number Of Files To Process = " + NumberOfFilesToProcess + " x 10000");
            Console.WriteLine("Batch Size = " + BatchSaveSize);

            List<string> files = FileHelper.GetFiles(NumberOfFilesToProcess);
            var organisationImporter = new OrganisationImporter(); 

            for (int i = 0; i < files.Count; i++)
            {
                organisationImporter.ImportFile(files[i], BatchSaveSize); 
            }
        }

        [Benchmark]
        public void ParallelForLoop()
        {
            var organisationImporter = new OrganisationImporter();
            List<string> files = FileHelper.GetFiles(NumberOfFilesToProcess);

            Parallel.ForEach(files, file =>
            {                
                organisationImporter.ImportFile(file, BatchSaveSize);
            });
        }

        [Benchmark]
        public async Task ParallelForLoopAsync()
        {
            var organisationImporter = new OrganisationImporter();
            List<string> files = FileHelper.GetFiles(NumberOfFilesToProcess);             

            await Parallel.ForEachAsync(files, new ParallelOptions { MaxDegreeOfParallelism = MaxDegreeOfParallelism }, async (file, cancellationToken) =>
            { 
                await organisationImporter.ImportFileAsync(file, BatchSaveSize); 
            }); 
        } 
    }     
}
using BenchmarkParallelForConsole.Service;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace BenchmarkParallelForConsole
{
    [IterationCount(1)]
    [SimpleJob(RunStrategy.ColdStart)]
    public class ParallelFor
    {
        private const int NumberOfFilesToProcess = 10;
        private const string FileName = "organizations-10000-1";
        private const int BatchSaveSize = 250;

        [Benchmark]
        public void ForLoop()
        {
            Console.WriteLine("Number Of Files To Process = " + NumberOfFilesToProcess + " x 10000");
            Console.WriteLine("Batch Size = " + BatchSaveSize);

            List<string> files = GetFiles(NumberOfFilesToProcess);
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
            List<string> files = GetFiles(NumberOfFilesToProcess);

            Parallel.ForEach(files, file =>
            {                
                organisationImporter.ImportFile(file, BatchSaveSize);
            });
        }

        [Benchmark]
        public async Task ParallelForLoopAsync()
        {
            var organisationImporter = new OrganisationImporter();
            List<string> files = GetFiles(NumberOfFilesToProcess);             

            await Parallel.ForEachAsync(files, new ParallelOptions { MaxDegreeOfParallelism = 2 }, async (file, cancellationToken) =>
            { 
                await organisationImporter.ImportFileAsync(file, BatchSaveSize); 
            }); 
        }
                 
        public List<string> GetFiles(int NumberOfFiles)
        {
            List<string> files = new List<string>();             
            for(int i = 0; i < NumberOfFiles; i++)
            {
                files.Add(FileName);
            }

            return files;
        }       
    }     
}
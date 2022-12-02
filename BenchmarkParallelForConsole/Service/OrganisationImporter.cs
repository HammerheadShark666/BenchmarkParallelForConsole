using BenchmarkParallelForConsole.Data;
using BenchmarkParallelForConsole.Mapper;
using BenchmarkParallelForConsole.Model;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BenchmarkParallelForConsole.Service
{
    public class OrganisationImporter
    {
        private const string FileExtension = ".csv";
        private const string filePath = @"D:\Software Development\Training\BenchmarkParallelForConsole\BenchmarkParallelForConsole\Csv\";
        
        public void ImportFile(string file, int batchSaveSize)
        {            
            var organisationRepository = new OrganisationRepository();
           
            using (var reader = new StreamReader($"{filePath}{file}{FileExtension}"))
            using (var csv = new CsvReader(reader, GetCsvConfiguration()))
            {
                csv.Context.RegisterClassMap<OrganisationMap>();
                var organisations = csv.GetRecords<Organisation>().ToList();

                int batchCount = 0;
                List<Organisation> batchToSave = new List<Organisation>();

                foreach (var organisation in organisations)
                {
                    batchToSave.Add(organisation);
                    batchCount++;

                    if (batchCount == batchSaveSize)
                    {
                        organisationRepository.SaveBatch(batchToSave);
                        batchCount = 0;
                        batchToSave.Clear();
                    }                      
                }

                organisationRepository.SaveBatch(batchToSave);
            } 
        }  

        public async Task ImportFileAsync(string file, int batchSaveSize)
        {
            var organisationRepository = new OrganisationRepository();
 
            using (var reader = new StreamReader($"{filePath}{file}{FileExtension}"))
            using (var csv = new CsvReader(reader, GetCsvConfiguration()))
            {
                csv.Context.RegisterClassMap<OrganisationMap>();
                var organisations = csv.GetRecordsAsync<Organisation>();

                int batchCount = 0;
                List<Organisation> batchToSave = new List<Organisation>();

                await foreach (var organisation in organisations)
                {
                    batchToSave.Add(organisation);
                    batchCount++;

                    if (batchCount == batchSaveSize)
                    {
                        await organisationRepository.SaveBatchAsync(batchToSave);
                        batchCount = 0;
                        batchToSave.Clear();
                    }         
                }

                await organisationRepository.SaveBatchAsync(batchToSave);
            }
        }

        private CsvConfiguration GetCsvConfiguration()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                Mode = CsvMode.RFC4180
            };
        }
    }
}

using BenchmarkParallelForConsole.Model;
using CsvHelper.Configuration;

namespace BenchmarkParallelForConsole.Mapper
{
    public class OrganisationMap : ClassMap<Organisation>
    {
        public OrganisationMap()
        { 
            Map(p => p.OrganisationId).Index(1);
            Map(p => p.Name).Index(2);
            Map(p => p.Website).Index(3);
            Map(p => p.Country).Index(4);
            Map(p => p.Description).Index(5);
            Map(p => p.Founded).Index(6);
            Map(p => p.Industry).Index(7);
            Map(p => p.NumberOfEmployees).Index(8);
        }
    }
}

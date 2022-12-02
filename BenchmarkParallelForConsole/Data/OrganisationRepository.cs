using BenchmarkParallelForConsole.Model;

namespace BenchmarkParallelForConsole.Data
{
    public class OrganisationRepository
    {
        public void Save(Organisation organisation)
        {
            using (var db = new OrganisationContext())
            {
                db.Add(organisation);
                db.SaveChanges();
            }
        }

        public void SaveBatch(List<Organisation> organisations)
        {
            using (var db = new OrganisationContext())
            {
                db.AddRange(organisations);
                db.SaveChanges();
            }
        }

        public async Task SaveAsync(Organisation organisation)
        {
            using (var db = new OrganisationContext())
            {
                db.Add(organisation);
                await db.SaveChangesAsync();
            }
        }

        public async Task SaveBatchAsync(List<Organisation> organisations)
        {
            using (var db = new OrganisationContext())
            {
                db.AddRange(organisations);
                await db.SaveChangesAsync();
            }
        }
    }
}

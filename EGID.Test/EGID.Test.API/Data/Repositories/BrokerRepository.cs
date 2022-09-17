using EGID.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public class BrokerRepository : Repository<Broker>, IBrokerRepository
    {
        public BrokerRepository(EGIDDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Broker>> GetAllAsync()
        {
            var data = await Task.FromResult(EGIDDbContext.Brokers);
            return data;
        }

        private EGIDDbContext EGIDDbContext
        {
            get { return Context as EGIDDbContext; }
        }
    }
}

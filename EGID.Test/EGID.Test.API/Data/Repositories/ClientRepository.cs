using EGID.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public class ClientRepository : Repository<Person>, IClientRepository
    {
        public ClientRepository(EGIDDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var data = await Task.FromResult(EGIDDbContext.Clients);
            return data;
        }

        private EGIDDbContext EGIDDbContext
        {
            get { return Context as EGIDDbContext; }
        }
    }
}

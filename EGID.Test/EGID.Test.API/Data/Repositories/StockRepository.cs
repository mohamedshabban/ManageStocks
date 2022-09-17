using EGID.Test.API.Data;
using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.Repositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public class StockRepository : Repository<Stock>,IStockRepository
    {
        public StockRepository(EGIDDbContext dbContext):base(dbContext)
        {
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            var data = await Task.FromResult(EGIDDbContext.Stocks);
             
            return data;
        }
       
        private EGIDDbContext EGIDDbContext
        {
            get { return Context as EGIDDbContext; }
        }
    }
}

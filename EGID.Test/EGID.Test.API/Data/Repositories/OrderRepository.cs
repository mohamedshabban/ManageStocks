using EGID.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EGIDDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var data = await Task.FromResult(EGIDDbContext.Orders.Include(c=>c.Person));
            return data;
        }

        private EGIDDbContext EGIDDbContext
        {
            get { return Context as EGIDDbContext; }
        }
    }
}

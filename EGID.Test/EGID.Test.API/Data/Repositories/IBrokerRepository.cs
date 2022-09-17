
using EGID.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public interface IBrokerRepository : IRepository<Broker>
    {
        Task<IEnumerable<Broker>> GetAllAsync();

    }
}

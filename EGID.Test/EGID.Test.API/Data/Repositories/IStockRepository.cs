
using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.Repositores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public interface IStockRepository:IRepository<Stock>
    {
        Task<IEnumerable<Stock>> GetAllAsync();

    }
}

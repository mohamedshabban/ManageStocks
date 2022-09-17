
using EGID.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Repositores
{
    public interface IClientRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> GetAllAsync();

    }
}

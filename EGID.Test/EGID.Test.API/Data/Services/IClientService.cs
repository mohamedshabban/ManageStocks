using EGID.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Person>> GetAllClients();
    }
}

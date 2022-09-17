using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Person>> GetAllClients()
        {
            return await _unitOfWork.Clients.GetAllAsync();
        }

        
    }
}

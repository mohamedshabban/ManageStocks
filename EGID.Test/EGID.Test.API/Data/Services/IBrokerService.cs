using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Services
{
    public interface IBrokerService
    {
        Task<IEnumerable<Broker>> GetAllBrokers();
    }
    public class BrokerService:IBrokerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrokerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Broker>> GetAllBrokers()
        {
            return await _unitOfWork.Brokers.GetAllAsync();
        }
    }
}

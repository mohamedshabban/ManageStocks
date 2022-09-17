using EGID.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> CreateOrder(Order newDepartment);
        Task<Order> GetOrderById(int id);
    }
}

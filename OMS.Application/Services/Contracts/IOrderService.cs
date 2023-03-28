
using Core.Entities;

namespace OMS.Application.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> GetById(int id);
        Task Add(Order order);
        Task Update(Order order);
        Task Delete(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities.Orders;

namespace WebStore.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel);

        Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName);

        Task<OrderDTO> GetOrderById(int id);
    }
}

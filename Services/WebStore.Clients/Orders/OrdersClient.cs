using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.DTO.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        public OrdersClient(IConfiguration Configuration) : base(Configuration, WebAPI.Orders) { }

        public async Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel)
        {
            var response = await PostAsync($"{_ServiceAddress}/{UserName}", OrderModel);
            return await response.Content.ReadAsAsync<OrderDTO>();
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) =>
            await GetAsync<IEnumerable<OrderDTO>>($"{_ServiceAddress}/user/{UserName}");

        public async Task<OrderDTO> GetOrderById(int id) => await GetAsync<OrderDTO>($"{_ServiceAddress}/{id}");
    }
}

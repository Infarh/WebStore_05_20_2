using System.Collections.Generic;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.DTO.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel Order { get; set; }

        public List<OrderItemDTO> Items { get; set; }
    }
}

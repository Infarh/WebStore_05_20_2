using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.DTO.Order
{
    public class OrderItemDTO : IBaseEntity
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
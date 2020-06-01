namespace WebStore.Domain.Entities.Base.Interfaces
{
    public interface IOrderedEntity : IBaseEntity
    {
        int Order { get; set; }
    }
}
namespace WebStore.Domain.Entityes.Base.Interfaces
{
    public interface IOrderedEntity : IBaseEntity
    {
        int Order { get; set; }
    }
}
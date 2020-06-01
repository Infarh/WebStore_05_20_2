using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
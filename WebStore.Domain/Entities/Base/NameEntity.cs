using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base;

public abstract class NameEntity : Entity, INamedEntity
{
    public string Name { get; set; }
}
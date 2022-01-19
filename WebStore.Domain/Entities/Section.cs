using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities;

public class Section : NameEntity, IOrderEntity
{
    public int Order { get; set; }
    public int? ParentId { get; set; }
}
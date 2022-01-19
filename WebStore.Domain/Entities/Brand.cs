using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities;

public class Brand : NameEntity, IOrderEntity
{
    public int Order { get; set; }
}
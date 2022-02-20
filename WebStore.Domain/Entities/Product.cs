using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities;

public class Product: NameEntity, IOrderEntity
{
    public Product()
    {
    }

    public Product(int id, string name, decimal price, string imageUrl, int order, int sectionId, int? brandId)
    {
        Id = id;
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        Order = order;
        SectionId = sectionId;
        BrandId = brandId;
    }

    public int Order { get; set; }
    public int SectionId { get; set; }
    public int? BrandId { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
}
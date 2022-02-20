using WebStore.Domain.Entities;

namespace WebStore.Data;

public class TestProducts
{
    public static IEnumerable<Product> Products { get; } = new[]
    {
        new Product(id: 1, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product7.jpg", order: 0, sectionId: 2, brandId: 1),
        new Product(id: 2, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product8.jpg", order: 1, sectionId: 2, brandId: 1),
        new Product(id: 3, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product9.jpg", order: 2, sectionId: 2, brandId: 1),
        new Product(id: 4, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product10.jpg", order: 3, sectionId: 2, brandId: 1),
        new Product(id: 5, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product11.jpg", order: 4, sectionId: 2, brandId: 2),
        new Product(id: 6, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product12.jpg", order: 5, sectionId: 2, brandId: 2),
        new Product(id: 7, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product7.jpg", order: 6, sectionId: 2, brandId: 2),
        new Product(id: 8, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product8.jpg", order: 7, sectionId: 25, brandId: 2),
        new Product(id: 9, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product9.jpg", order: 8, sectionId: 25, brandId: 2),
        new Product(id: 10, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product10.jpg", order: 9, sectionId: 25, brandId: 3),
        new Product(id: 11, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product11.jpg", order: 10, sectionId: 25, brandId: 3),
        new Product(id: 12, name: "Easy Polo Black Edition", price: 1025, imageUrl: "product12.jpg", order: 11, sectionId: 25, brandId: 3),
    };

}
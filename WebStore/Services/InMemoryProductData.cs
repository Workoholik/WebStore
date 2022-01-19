using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;

namespace WebStore.Services;

public class InMemoryProductData : IProductData
{
    public IEnumerable<Section> GetSections() => TestSection.Sections;

    public IEnumerable<Brand> GetBrand() => TestBrand.Brands;
}
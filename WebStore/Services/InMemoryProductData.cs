using WebStore.Data;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;

namespace WebStore.Services;

public class InMemoryProductData : IProductData
{
    public IEnumerable<Section> GetSections() => TestSection.Sections;

    public IEnumerable<Brand> GetBrands() => TestBrand.Brands;
    public IEnumerable<Product> GetProducts(ProductFilter? Filter = null)
    {
        IEnumerable <Product> query = TestProducts.Products;

        //if (Filter?.SectionId != null)
        //{
        //  query = query.Where(p => p.SectionId == Filter.SectionId);
        //}

        if (Filter?.SectionId is { } section) 
            query = query.Where((p => p.SectionId == section));

        if (Filter?.BrandId is {} brand) 
            query = query.Where(p => p.BrandId == brand);


        return query;
    }
}
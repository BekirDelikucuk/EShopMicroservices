using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        //Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();

    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Category = new List<string> { "Smart Phone", "Apple" },
                Description = "IPhone X",
                ImageFile = "product-1.png",
                Price = 950
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung 10",
                Category = new List<string> { "Smart Phone", "Samsung" },
                Description = "Samsung 10",
                ImageFile = "product-2.png",
                Price = 850
            }
        };

}



namespace CatalogAPI.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync()) return;

            session.Store<Product>(GetPreConfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static List<Product> GetPreConfiguredProducts() => new List<Product>
        {
            new Product()
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "Samsung Galaxy S21",
                Description = "Flagship smartphone with cutting-edge features.",
                ImageFile = "product-2.png",
                Price = 799.99M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = "MacBook Pro 14\"",
                Description = "Powerful laptop with M1 Pro chip.",
                ImageFile = "product-3.png",
                Price = 1999.00M,
                Category = new List<string> { "Laptop" }
            },
            new Product()
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = "Sony WH-1000XM4",
                Description = "Wireless noise-cancelling headphones.",
                ImageFile = "product-4.png",
                Price = 349.99M,
                Category = new List<string> { "Headphones" }
            },
            new Product()
            {
                Id = new Guid("44444444-4444-4444-4444-444444444444"),
                Name = "Apple iPad Pro 11\"",
                Description = "Tablet with Liquid Retina display.",
                ImageFile = "product-5.png",
                Price = 799.00M,
                Category = new List<string> { "Tablet" }
            },
            new Product()
            {
                Id = new Guid("55555555-5555-5555-5555-555555555555"),
                Name = "Dell XPS 13",
                Description = "Ultrabook with InfinityEdge display.",
                ImageFile = "product-6.png",
                Price = 1299.99M,
                Category = new List<string> { "Laptop" }
            },
            new Product()
            {
                Id = new Guid("66666666-6666-6666-6666-666666666666"),
                Name = "Google Pixel 7",
                Description = "Android smartphone with excellent camera.",
                ImageFile = "product-7.png",
                Price = 599.99M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = new Guid("77777777-7777-7777-7777-777777777777"),
                Name = "Bose QuietComfort 45",
                Description = "Comfortable noise-cancelling headphones.",
                ImageFile = "product-8.png",
                Price = 329.99M,
                Category = new List<string> { "Headphones" }
            },
            new Product()
            {
                Id = new Guid("88888888-8888-8888-8888-888888888888"),
                Name = "Microsoft Surface Pro 9",
                Description = "2-in-1 laptop with tablet functionality.",
                ImageFile = "product-9.png",
                Price = 999.00M,
                Category = new List<string> { "Tablet" }
            },
            new Product()
            {
                Id = new Guid("99999999-9999-9999-9999-999999999999"),
                Name = "Canon EOS R5",
                Description = "Professional mirrorless camera.",
                ImageFile = "product-10.png",
                Price = 3899.00M,
                Category = new List<string> { "Camera" }
            },
            new Product()
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "PlayStation 5",
                Description = "Next-gen gaming console.",
                ImageFile = "product-11.png",
                Price = 499.99M,
                Category = new List<string> { "Gaming Console" }
            }
        };

    }
}



namespace CatalogAPI.Products.GetProducts
{
    public record GetProductsQuery():IQuery<GetProductsResults>;
    public record GetProductsResults(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResults>
    {
        public async Task<GetProductsResults> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle Called with {@Query}", query);

            var product = await session.Query<Product>().ToListAsync(cancellationToken); 

            return new GetProductsResults(product);
        }
    }
}

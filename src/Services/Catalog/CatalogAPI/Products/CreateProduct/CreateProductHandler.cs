
namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price):ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session): ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            #region Create Product Entity from Command Object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,  
            };
            #endregion

            #region Save to  Database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);   
            #endregion

            #region  Return CreateProductResult result          
            return  new CreateProductResult(product.Id);
            #endregion
        }
    }
}

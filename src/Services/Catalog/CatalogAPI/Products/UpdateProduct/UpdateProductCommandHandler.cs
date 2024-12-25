
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace CatalogAPI.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, 
                                        string Description, string ImageFile, decimal Price)
    :ICommand<UpdateProductResult>;
    public record UpdateProductResult (bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Product ID is Required");
            RuleFor(command => command.Name).NotEmpty().Length(2,150).WithMessage("Name Must be 2 to 150 Characters");
            RuleFor(command => command.Price).GreaterThan(0).WithMessage("Price must be grater than 0");
        }
    }
    internal class UpdateProductCommandHandler (IDocumentSession session,ILogger<UpdateProductCommandHandler> logger)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}",command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);

        }
    }
}

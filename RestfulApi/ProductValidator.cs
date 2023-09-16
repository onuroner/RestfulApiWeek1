using FluentValidation;
using RestfulApi.Base.Models;

namespace RestfulApi
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price should be greater than zero.");
        }
    }
}

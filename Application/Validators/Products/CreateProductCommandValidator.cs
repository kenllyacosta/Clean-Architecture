using Application.Commands.Products;
using FluentValidation;
using System;

namespace Application.Validators.Products
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("El producto debe tener Nombre");
            RuleFor(x => x.Product.FechaCreado).GreaterThan(DateTime.MinValue).WithMessage("{PropertyName} debe tener un valor válido");
        }
    }
}

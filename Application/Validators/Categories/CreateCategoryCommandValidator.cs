using Application.Commands.Categories;
using FluentValidation;
using System;

namespace Application.Validators.Categories
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Category.Name).NotEmpty().WithMessage("Debes proporcionar el nombre de la categoria.");
            RuleFor(x => x.Category.FechaCreado).GreaterThan(DateTime.MinValue).WithMessage("{PropertyName} debe tener un valor válido");
            //...
        }
    }
}

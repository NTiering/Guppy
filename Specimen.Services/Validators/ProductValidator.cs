namespace Specimen.Services.Validators
{
    using FluentValidation;
    using Contracts.DataModels;
    using System;


    class ProductValidator : AbstractValidator<ProductDataModel>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("Please specify a name");
        }
    }

}
namespace Specimen.Services.Validators
{
    using FluentValidation;
    using Contracts.DataModels;
    using System;

    class OrderValidator : AbstractValidator<OrderDataModel>
    {
        public OrderValidator()
        {
            RuleFor(product => product.DeliverDate)
            .NotEqual(DateTime.MinValue)
            .WithMessage("Please specify a deliver date");
        }
    }

}
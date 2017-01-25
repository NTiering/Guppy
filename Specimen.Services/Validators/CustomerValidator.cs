using FluentValidation;
using Specimen.Contracts.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specimen.Services.Validators
{
    class CustomerValidator : AbstractValidator<CustomerDataModel>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
            .NotEmpty()
            .WithMessage("Please specify a name");
        }
    }




}

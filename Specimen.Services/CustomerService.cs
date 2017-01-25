namespace Specimen.Services
{
    using System.Collections.Generic;
    using Guppy.Contracts;
    using Guppy.Services;
    using FluentValidation;
    using System.Linq;
    using Contracts;
    using Contracts.DataModels;

    class CustomerService : BaseService<CustomerDataModel>
    {
        private IValidator<CustomerDataModel> validator;

        public CustomerService(IDal<CustomerDataModel> dal, IValidator<CustomerDataModel> validator) : base(dal)
        {
            this.validator = validator;
        }

        protected override bool IsValid(CustomerDataModel item, List<IModelError> errors)
        {
            var result = validator.Validate(item);         

            errors.AddRange(
                result
                .Errors
                .Select(x => new ModelError
                {
                    Property = x.PropertyName,
                    ErrorMessage = x.ErrorMessage
                })
                .Cast<IModelError>()
            );

            return result.IsValid;
        }
    }
}

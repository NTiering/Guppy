namespace Specimen.Services
{
    using Guppy.Contracts;
    using Guppy.Services;
    using FluentValidation;
    using Contracts;
    using Contracts.DataModels;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Contracts.Services;
    using Contracts.Dals;

    class OrderService : BaseService<OrderDataModel>, IOrderService
    {
        private IOrderDal orderDal;
        private IValidator<OrderDataModel> validator;

        public OrderService(IOrderDal dal, IValidator<OrderDataModel> validator) : base(dal)
        {
            orderDal = dal;
            this.validator = validator;
        }

        public IEnumerable<OrderDataModel> GetAllOnDeliveryDate(DateTime deliverDate, IModelContext context = null)
        {
            return orderDal.GetAllOnDeliveryDate(deliverDate, context);
        }

        protected override bool IsValid(OrderDataModel item, List<IModelError> errors)
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
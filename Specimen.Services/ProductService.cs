
namespace Specimen.Services
{
    using Guppy.Contracts;
    using Guppy.Services;
    using Contracts.DataModels;
    using Contracts.Services;
    using System.Linq;
    using System.Collections.Generic;
    using FluentValidation;
    using Contracts;

    class ProductService : BaseService<ProductDataModel>, IProductService
    {
        private IValidator<CustomerDataModel> validator;

        public ProductService(IDal<ProductDataModel> dal, IValidator<CustomerDataModel> validator) : base(dal)
        {
             this.validator = validator;
        }

        /// <summary>
        /// Gets Stock items in stock with name starting with 'Name'
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public IEnumerable<ProductDataModel> GetAllInStockByName(string name, IModelContext context = null)
        {
            // without modifying the Dal 
            return dal.GetAll(x => x.InStock == true && x.Name.StartsWith(name), context).AsEnumerable();
                        
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValid(ProductDataModel item, List<IModelError> errors)
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
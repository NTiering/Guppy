namespace Guppy.Auth.Validator
{
    using Contracts.Validator;
    using Models;
    using Guppy.Contracts;
    using FluentValidation;
    using System.Linq;

    class AccountValidator : BaseValidator<AccountDataModel>, IAccountValidator
    {
        private IDal<AccountDataModel> dal;

        public AccountValidator(IDal<AccountDataModel> dal)
        {
            this.dal = dal;
            RuleFor(model => model.Username).NotEmpty().WithMessage("email_missing");
            RuleFor(model => model.Password).NotEmpty().WithMessage("password_missing");
            RuleFor(model => model.Username).EmailAddress().WithMessage("email_invalid");
            RuleFor(model => model.Username).Must(NotBeInUse).WithMessage("email_in_use");
            RuleFor(model => model.Password).Length(6,25).WithMessage("password_length");
        }

        ///// <summary>
        ///// Returns true if ... is valid.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <param name="errors">The errors.</param>
        ///// <returns>
        /////   <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        ///// </returns>
        //public bool IsValid(AccountDataModel item, List<IModelError> errors)
        //{
        //    return item == null ? NullItem(errors) : Validate(item, errors);
        //}


        ///// <summary>
        ///// Validates the specified item.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <param name="errors">The errors.</param>
        ///// <returns></returns>
        //private bool Validate(AccountDataModel item, List<IModelError> errors)
        //{
        //    var result = Validate(item);
        //    errors.AddRange(result.Errors.ToModelErrors());
        //    return result.IsValid;
        //}

        ///// <summary>
        ///// Nulls the item.
        ///// </summary>
        ///// <param name="errors">The errors.</param>
        ///// <returns></returns>
        //private bool NullItem(List<IModelError> errors)
        //{
        //    errors.Add(new ModelError { ErrorMessage = "Null Model", Property = "*" });
        //    return false;
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        private bool NotBeInUse(AccountDataModel arg, string email)
        {
            if (arg.IsNew)
            {
                return (dal.GetAll(x => { return x.Username != arg.Username; }, null).Any() == false);
            }
            else
            {
                return (dal.GetAll(x => { return x.Username != arg.Username && x.Id != arg.Id; }, null).Any() == false);
            }
        }

    }
}

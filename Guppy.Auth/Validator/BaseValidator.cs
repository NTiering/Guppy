namespace Guppy.Auth.Validator
{
    using Models;
    using Guppy.Contracts;
    using FluentValidation;
    using Helpers;
    using System.Collections.Generic;
    using Guppy.Contracts.Models;

    abstract class BaseValidator<T> : AbstractValidator<T>
        where T : IDataModel
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid(T item, List<IModelError> errors)
        {
            return item == null ? NullItem(errors) : Validate(item, errors);
        }


        /// <summary>
        /// Validates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        protected virtual bool Validate(T item, List<IModelError> errors)
        {
            var result = Validate(item);
            errors.AddRange(result.Errors.ToModelErrors());
            return result.IsValid;
        }

        /// <summary>
        /// Nulls the item.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        protected virtual bool NullItem(List<IModelError> errors)
        {
            errors.Add(new ModelError { ErrorMessage = "Null Model", Property = "*" });
            return false;
        }
    }

}
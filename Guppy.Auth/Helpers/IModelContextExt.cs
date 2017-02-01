namespace Guppy.Auth.Helpers
{
    using Contracts.Model;
    using FluentValidation.Results;
    using Guppy.Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class IList_ValidationFailure
    {
        /// <summary>
        /// To the model errors.
        /// </summary>
        /// <param name="ve">The ve.</param>
        /// <returns></returns>
        public static IEnumerable<IModelError> ToModelErrors(this IList<ValidationFailure> ve)
        {
            var errors = new List<IModelError>();
            ve.ToList().ForEach(e =>
            {
                errors.Add(new ModelError { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
            });

            return errors;            
        }
    }

    static class IModelContextExt
    {
        /// <summary>
        /// To a authentication model context.
        /// </summary>
        /// <param name="modelContext">The model context.</param>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Unable to cast model context to IAuthModelContext</exception>
        public static IAuthModelContext ToAuthModelContext(this IModelContext modelContext, bool throwException = true)
        {
            var rtn = modelContext as IAuthModelContext;
            if (throwException && rtn == null)
            {
                throw new InvalidCastException("Unable to cast model context to IAuthModelContext");
            }
            return rtn;
        }
    }
}

namespace Guppy.Auth.Contracts.Validator
{
    using Models;
    using Guppy.Contracts;
    using System.Collections.Generic;

    interface IRightValidator
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(RightDataModel item, List<IModelError> errors);
    }

}
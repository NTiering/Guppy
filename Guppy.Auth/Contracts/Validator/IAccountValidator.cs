namespace Guppy.Auth.Contracts.Validator
{
    using Models;
    using Guppy.Contracts;
    using System.Collections.Generic;

    interface IAccountValidator
    {
        bool IsValid(AccountDataModel item, List<IModelError> errors);
    }
}

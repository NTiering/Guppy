namespace Guppy.Auth.Contracts.Validator
{
    using Models;
    using Guppy.Contracts;
    using System.Collections.Generic;

    interface IRoleValidator
    {
        bool IsValid(RoleDataModel item, List<IModelError> errors);
    }

}
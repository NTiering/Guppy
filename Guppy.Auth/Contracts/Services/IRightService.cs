namespace Guppy.Auth.Contracts.Services
{
    using Guppy.Contracts;
    using Models;
    using System.Collections.Generic;

    public interface IRightService : IService<RightDataModel>
    {
        /// <summary>
        /// Gets the rights by role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IEnumerable<RightDataModel> GetRightsByRoleId(int roleId, IModelContext context = null);

        /// <summary>
        /// Gets the rights by account identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<RightDataModel> GetRightsByAccountId(int id, IModelContext context = null);
    }

}
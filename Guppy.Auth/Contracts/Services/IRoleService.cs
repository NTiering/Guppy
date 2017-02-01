namespace Guppy.Auth.Contracts.Services
{
    using Guppy.Contracts;
    using Models;
    using System.Collections.Generic;

    public interface IRoleService : IService<RoleDataModel>
    {
        /// <summary>
        /// Gets the roles by account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        IEnumerable<RoleDataModel> GetRolesByAccountId(int accountId);

        /// <summary>
        /// Tries the add roles to account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        bool TryAddRolesToAccountId(int accountId, params int[] roleIds);

        /// <summary>
        /// Tries the remove roles from account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        bool TryRemoveRolesFromAccountId(int accountId, params int[] roleIds);

        /// <summary>
        /// Tries the add right to role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="rightId">The right identifier.</param>
        /// <returns></returns>
        bool TryAddRightToRole(int roleId, int rightId, IModelContext context = null);

        /// <summary>
        /// Tries the remove right from role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="rightId">The right identifier.</param>
        /// <returns></returns>
        bool TryRemoveRightFromRole(int roleId, int rightId, IModelContext context = null);



    }

}
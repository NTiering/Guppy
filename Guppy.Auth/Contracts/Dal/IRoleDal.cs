namespace Guppy.Auth.Contracts.Dal
{
    using Models;
    using Guppy.Contracts;
    using System;
    using System.Linq;

    public interface IRoleDal
    {
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void Create(RoleDataModel item, IModelContext context);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void Delete(int id, IModelContext context);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        RoleDataModel Get(int id, IModelContext context);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        RoleDataModel Get(Func<RoleDataModel, bool> filter, IModelContext context);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IQueryable<RoleDataModel> GetAll(Func<RoleDataModel, bool> filter, IModelContext context);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void Update(RoleDataModel item, IModelContext context);
    }

}
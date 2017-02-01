namespace Guppy.Auth.Contracts.Dal
{
    using System;
    using System.Linq;
    using Models;
    using Guppy.Contracts;

    public interface IAccountDal
    {
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void Create(AccountDataModel item, IModelContext context);

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
        AccountDataModel Get(int id, IModelContext context);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        AccountDataModel Get(Func<AccountDataModel, bool> filter, IModelContext context);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IQueryable<AccountDataModel> GetAll(Func<AccountDataModel, bool> filter, IModelContext context);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void Update(AccountDataModel item, IModelContext context);
    }

}
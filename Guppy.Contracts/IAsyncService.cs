namespace Guppy.Contracts
{
    using Models;
    using System.Threading.Tasks;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public interface IAsyncService<T> where T : IDataModel
    {
        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> Get(int id, IModelContext context = null);

        /// <summary>
        /// Gets the specified item by filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        Task<T> Get(Func<T, bool> filter, IModelContext context = null);

        /// <summary>
        /// Gets all the items that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        Task<IQueryable<T>> GetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999);

        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task<bool> TryDelete(int id, IModelContext context = null);

        /// <summary>
        /// Tries to save the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        Task<bool> TrySave(T item, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Tries to validate a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        Task<bool> TryValidate(T item, string propertyName, List<IModelError> errors, IModelContext context = null);

    }

}
namespace Guppy.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public partial interface IDal<T> where T : class, IDataModel
    {
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Create(T item, IModelContext context);

        /// <summary>
        /// Deletes the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id, IModelContext context);

        /// <summary>
        /// Gets the specified item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get(int id, IModelContext context);

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        T Get(Func<T, bool> filter, IModelContext context);

        /// <summary>
        /// Gets all items that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(Func<T, bool> filter, IModelContext context);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Update(T item, IModelContext context);
    }
}
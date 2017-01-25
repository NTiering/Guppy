namespace Guppy.Contracts
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IService<T> where T : class, IDataModel
    {
        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        bool TryDelete(int id, IModelContext context = null);

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get(int id, IModelContext context = null);

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        T Get(Func<T, bool> filter, IModelContext context = null);

        /// <summary>
        /// Gets all the items that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999);

        /// <summary>
        /// Tries to save the itme.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        bool TrySave(T item, out List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Tries validation on a single property.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TryValidate(T item, string propertyName, out List<IModelError> errors, IModelContext context = null);

    }
}
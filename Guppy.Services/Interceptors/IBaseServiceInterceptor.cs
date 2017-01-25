namespace Guppy.Services.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Contracts.Models;

    public interface IBaseServiceInterceptor<T> where T : class, IDataModel
    {
        /// <summary>
        /// Called after the get action.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void AfterGet(T item, int id, IModelContext context = null);

        /// <summary>
        ///  Called after the get action.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        void AfterGet(T item, Func<T, bool> filter, IModelContext context = null);

        /// <summary>
        ///  Called after the get all action.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        void AfterGetAll(IQueryable<T> items, Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999);

        /// <summary>
        ///  Called after the delete action.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void AfterTryDelete(bool result, int id, IModelContext context = null);

        /// <summary>
        ///  Called after the save action.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        void AfterTrySave(bool result, T item, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Called before the get action.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void BeforeGet(int id, IModelContext context = null);

        /// <summary>
        /// Called before the get action.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        void BeforeGet(Func<T, bool> filter, IModelContext context = null);

        /// <summary>
        /// Called before the get all action.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        void BeforeGetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999);

        /// <summary>
        /// Called before the delete all action.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void BeforeTryDelete(int id, IModelContext context = null);

        /// <summary>
        /// Called before the try save action.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeTrySave(T item, IModelContext context = null);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        T Get(int id, IModelContext context = null);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        T Get(Func<T, bool> filter, IModelContext context = null);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999);

        /// <summary>
        /// Tries the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TryDelete(int id, IModelContext context = null);

        /// <summary>
        /// Tries the save.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TrySave(T item, out List<IModelError> errors, IModelContext context = null);
    }
}
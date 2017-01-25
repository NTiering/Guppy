namespace Guppy.Dal.Interceptors
{
    using Contracts;
    using Contracts.Models;
    using System;
    using System.Linq;

    public interface IDalInterceptor<T> : IDal<T>
        where T : class,IDataModel
    {
        /// <summary>
        /// Called before the create function.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeCreate(T item, IModelContext context);

        /// <summary>
        /// Called after the create function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterCreate(T item, IModelContext context);

        /// <summary>
        /// Called before the delete function
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void BeforeDelete(int id, IModelContext context);

        /// <summary>
        /// Called after the delete function
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void AfterDelete(int id, IModelContext context);

        /// <summary>
        /// called before the get function
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void BeforeGet(int id, IModelContext context);

        /// <summary>
        /// Called after the get function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        void AfterGet(T item, int id, IModelContext context);

        /// <summary>
        /// Called before the get function
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        void BeforeGet(Func<T, bool> filter, IModelContext context);

        /// <summary>
        /// Called after the get function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        void AfterGet(T item,Func<T, bool> filter, IModelContext context);

        /// <summary>
        /// Called before the get all function
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        void BeforeGetAll(Func<T, bool> filter, IModelContext context);

        /// <summary>
        /// Called after the get all function
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        void AfterGetAll(IQueryable<T> result, Func<T, bool> filter, IModelContext context);

        /// <summary>
        /// Called before the update function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeUpdate(T item, IModelContext context);

        /// <summary>
        /// Called after the update function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterUpdate(T item, IModelContext context);

    }
}

namespace Guppy.Dal.Interceptors
{
    using Contracts;
    using Contracts.Models;
    using System;
    using System.Linq;

    public abstract class BaseInterceptor<T> : IDalInterceptor<T> where T : class, IDataModel
    {
        IDal<T> dal;

        protected BaseInterceptor(IDal<T> dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Called after the create function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterCreate(T item, IModelContext context)
        {
        }

        /// <summary>
        /// Called after the delete function
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterDelete(int id, IModelContext context)
        {
        }

        /// <summary>
        /// Called after the get function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterGet(T item, Func<T, bool> filter, IModelContext context)
        {
        }

        /// <summary>
        /// Called after the get function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterGet(T item, int id, IModelContext context)
        {
        }

        /// <summary>
        /// Called after the get all function
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterGetAll(IQueryable<T> result, Func<T, bool> filter, IModelContext context)
        {
        }

        /// <summary>
        /// Called after the update function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterUpdate(T item, IModelContext context)
        {
        }

        /// <summary>
        /// Called before the create function.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeCreate(T item, IModelContext context)
        {
        }

        /// <summary>
        /// Called before the delete function
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeDelete(int id, IModelContext context)
        {
        }

        /// <summary>
        /// Called before the get function
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeGet(Func<T, bool> filter, IModelContext context)
        {
        }

        /// <summary>
        /// called before the get function
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeGet(int id, IModelContext context)
        {
        }

        /// <summary>
        /// Called before the get all function
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeGetAll(Func<T, bool> filter, IModelContext context)
        {
        }

        /// <summary>
        /// Called before the update function
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeUpdate(T item, IModelContext context)
        {
        }

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context"></param>
        public virtual void Create(T item, IModelContext context)
        {
            BeforeCreate(item, context);
            dal.Create(item, context);
            AfterCreate(item, context);
        }

        /// <summary>
        /// Deletes the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        public virtual void Delete(int id, IModelContext context)
        {
            BeforeDelete(id, context);
            dal.Delete(id, context);
            AfterDelete(id, context);
        }

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual T Get(Func<T, bool> filter, IModelContext context)
        {
            BeforeGet(filter, context);
            var rtn = dal.Get(filter, context);
            AfterGet(rtn, filter, context);
            return rtn;
        }

        /// <summary>
        /// Gets the specified item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual T Get(int id, IModelContext context)
        {
            BeforeGet(id, context);
            var rtn = dal.Get(id, context);
            AfterGet(rtn, id, context);
            return rtn;
        }

        /// <summary>
        /// Gets all items that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Func<T, bool> filter, IModelContext context)
        {
            BeforeGetAll(filter, context);
            var rtn = dal.GetAll(filter, context);
            AfterGetAll(rtn, filter, context);
            return rtn;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context"></param>
        public virtual void Update(T item, IModelContext context)
        {
            BeforeUpdate(item,context);
            dal.Update(item, context);
            AfterUpdate(item, context);
        }
    }
}

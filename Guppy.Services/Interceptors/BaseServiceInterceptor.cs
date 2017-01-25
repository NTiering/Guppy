namespace Guppy.Services.Interceptors
{
    using Contracts;
    using Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseServiceInterceptor<T> : IService<T>, IBaseServiceInterceptor<T> 
        where T : class, IDataModel
    {
        protected IService<T> service { get; private set; }

        protected BaseServiceInterceptor(IService<T> service)
        {
            this.service = service;
        }

        /// <summary>
        /// Called before the get action.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeGet(Func<T, bool> filter, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called after the get action.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterGet(T item, Func<T, bool> filter, IModelContext context = null)
        {
        }

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual T Get(Func<T, bool> filter, IModelContext context = null)
        {
            BeforeGet(filter, context);
            var rtn = service.Get(filter, context);
            AfterGet(rtn, filter, context);
            return rtn;
        }

        /// <summary>
        /// Called before the get action.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeGet(int id, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called after the get action.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterGet(T item, int id, IModelContext context = null)
        {
        }

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual T Get(int id, IModelContext context = null)
        {
            BeforeGet(id, context);
            var rtn = service.Get(id, context);
            AfterGet(rtn, id, context);
            return rtn;
        }

        /// <summary>
        /// Called before the get all action.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        public virtual void BeforeGetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
        }

        /// <summary>
        /// Called after the get all action.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        public virtual void AfterGetAll(IQueryable<T> items,Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
        }

        /// <summary>
        /// Gets all the items that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context"></param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
            BeforeGetAll(filter, context, order, skip, take);
            var rtn = GetAll(filter, context, order, skip, take);
            AfterGetAll(rtn,filter, context, order, skip, take);
            return rtn;
        }

        /// <summary>
        /// Called before the delete all action.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeTryDelete(int id, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called after the delete action.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterTryDelete(bool result, int id, IModelContext context = null)
        {
        }

        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool TryDelete(int id, IModelContext context = null)
        {
            BeforeTryDelete(id, context);
            var rtn = service.TryDelete(id, context);
            AfterTryDelete(rtn, id, context);
            return rtn;
        }

        /// <summary>
        /// Called after the save action.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterTrySave(bool result, T item, List<IModelError> errors, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called before the try save action.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeTrySave(T item,  IModelContext context = null)
        {

        }

        /// <summary>
        /// Tries to save the itme.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool TrySave(T item, out List<IModelError> errors, IModelContext context = null)
        {
            BeforeTrySave(item, context);
            var rtn = service.TrySave(item, out errors, context);
            AfterTrySave(rtn, item,errors, context);
            return rtn;
        }

        /// <summary>
        /// Tries validation on a single property.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool TryValidate(T item, string propertyName, out List<IModelError> errors, IModelContext context = null)
        {
            BeforeTryValidate(item, propertyName,context);
            var rtn = service.TrySave(item, out errors, context);
            AfterTryValidate(rtn, item, propertyName,errors, context);
            return rtn;
        }

        /// <summary>
        /// After the try validate.
        /// </summary>
        /// <param name="rtn">if set to <c>true</c> [RTN].</param>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterTryValidate(bool rtn, T item, string propertyName, List<IModelError> errors, IModelContext context)
        {
           
        }

        /// <summary>
        /// Before the try validate.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeTryValidate(T item, string propertyName, IModelContext context)
        {
            
        }
    }
}

namespace Guppy.Services
{
    using Contracts;
    using Contracts.Models;
    using System.Threading.Tasks;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BaseAsyncService<T> : IAsyncService<T>
        where T : class,IDataModel
    {
        private IService<T> coreService;

        public BaseAsyncService(IService<T> coreService)
        {
            this.coreService = coreService;
        }

        /// <summary>
        /// Tries to save the itme.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> TrySave(T item, List<IModelError> errors, IModelContext context = null)
        {
            if (errors == null) throw new ArgumentNullException("errors");

            return await Task.Run(() =>
            {
                var results = new List<IModelError>();
                bool rtn = coreService.TrySave(item, out results, context);
                errors.AddRange(results);
                return rtn;
            });
        }

        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> TryDelete(int id, IModelContext context = null)
        {
            return await Task.Run(() =>
            {
                bool rtn = coreService.TryDelete(id, context);
                return rtn;
            });
        }

        /// <summary>
        /// Tries to validate a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName"></param>
        /// <param name="errors">The errors.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> TryValidate(T item, string propertyName, List<IModelError> errors, IModelContext context = null)
        {
            if (errors == null) throw new ArgumentNullException("errors");

            return await Task.Run(() =>
            {
                var results = new List<IModelError>();
                bool rtn = coreService.TryValidate(item, propertyName, out results, context);
                errors.AddRange(results);
                return rtn;
            });
        }

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<T> Get(int id, IModelContext context = null)
        {
            return await Task.Run(() =>
            {
                return coreService.Get(id, context);
            });
        }

        /// <summary>
        /// Gets the specified item by filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task<T> Get(Func<T, bool> filter, IModelContext context = null)
        {
            return await Task.Run(() =>
            {
                return coreService.Get(filter, context);
            });
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
        public async Task<IQueryable<T>> GetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
            return await Task.Run(() =>
            {
                return coreService.GetAll(filter, context, order, skip, take);
            });
        }        
    }

}
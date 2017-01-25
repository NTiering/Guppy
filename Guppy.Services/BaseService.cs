namespace Guppy.Services
{
    using Contracts;
    using Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseService<T> : IService<T> where T : class, IDataModel
    {
        protected IDal<T> dal { get; private set; }
       
        protected BaseService(IDal<T> dal)
        {
            this.dal = dal;
        }
        
        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T Get(int id, IModelContext context = null)
        {
            return dal.Get(id, context);
        }

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public virtual T Get(Func<T,bool> filter, IModelContext context = null)
        {
            return dal.Get(filter, context);
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Func<T, bool> filter, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
            var rtn = dal.GetAll(filter, context);
            if (order != null)
            {
                return rtn.OrderBy(order).Skip(skip).Take(take).AsQueryable();
            }
            else
            {
                return rtn.Skip(skip).Take(take).AsQueryable();
            }
        }

        /// <summary>
        /// Checks the validation of a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public virtual bool TryValidate(T item, string propertyName, out List<IModelError> errors, IModelContext context = null)
        {
            bool rtn;
            ValidateModel(item, out errors, out rtn);
            errors.RemoveAll(x => string.Compare(x.Property, propertyName,true) != 0);
            return rtn;
        }

        /// <summary>
        /// Tries to save the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public virtual bool TrySave(T item, out List<IModelError> errors, IModelContext context = null)
        {
            bool rtn;
            ValidateModel(item, out errors, out rtn);
            if (rtn == true)
            {
                if (item.IsNew)
                {
                    dal.Create(item, context);                  
                }
                else
                {
                    dal.Update(item, context);
                }
            }

            return rtn;
        }
        
        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual bool TryDelete(int id, IModelContext context = null)
        {
            var exists = (dal.Get(id,context) != null);
            if (!exists) return false;
            dal.Delete(id,context);
            return true;
        }

        /// <summary>
        /// Adds the null model error.
        /// </summary>
        /// <param name="errors">The errors.</param>
        protected virtual void AddNullModelError(List<IModelError> errors)
        {
            errors.Add(new ModelError { Property = "", ErrorMessage = "noModel" });
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="rtn">if set to <c>true</c> [RTN].</param>
        protected virtual void ValidateModel(T item, out List<IModelError> errors, out bool rtn)
        {
            errors = new List<IModelError>();
            rtn = true;
            if (item == null)
            {
                AddNullModelError(errors);
                rtn = false;
            }
            else if (IsValid(item, errors) == false)
            {
                rtn = false;
            }
        }

        /// <summary>
        /// Returns true if item is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool IsValid(T item, List<IModelError> errors);

    }

}
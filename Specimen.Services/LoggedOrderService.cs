namespace Specimen.Services
{
    using Guppy.Contracts;
    using Contracts.DataModels;
    using Guppy.Services.Interceptors;
    using Contracts.Services;
    using System;
    using System.Collections.Generic;
    using Dal;
    using System.Security;

    class LoggedOrderService : BaseServiceInterceptor<OrderDataModel>, ILoggedOrderService
    {
        private IOrderService orderService;

        public LoggedOrderService(IService<OrderDataModel> service) : base(service)
        {
            orderService = service as IOrderService;
            if(orderService == null) throw new ArgumentException("IOrderService");
        }

        /// <summary>
        /// Gets all on delivery date.
        /// </summary>
        /// <param name="deliverDate">The deliver date.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public IEnumerable<OrderDataModel> GetAllOnDeliveryDate(DateTime deliverDate, IModelContext context = null)
        {
            var ctx = context as ISpecimenModelContext;
            if (ctx == null) throw new ArgumentException("context");
            LogUserAction("GetAllOnDeliveryDate", ctx.UserId);

            var rtn = orderService.GetAllOnDeliveryDate(deliverDate, context);
            
            return rtn;
        }

        /// <summary>
        /// Called before the get action.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentException">context</exception>
        /// <exception cref="System.Security.SecurityException">uh oh ...</exception>
        public override void BeforeGet(int id, IModelContext context = null)
        {
            var ctx = context as ISpecimenModelContext;
            if (ctx == null) throw new ArgumentException("context");


            if (UserIsNotAllowed("get",ctx.UserId, id))
            {
                throw new SecurityException("uh oh ...");
            }            

            LogUserAction("get", ctx.UserId, id);
        }               


        /// <summary>
        /// Called after the save action.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        public override void AfterTrySave(bool result, OrderDataModel item, List<IModelError> errors, IModelContext context = null)
        {            
            if (result && item.IsNew)
            {
                var ctx = context as ISpecimenModelContext;
                if (ctx == null) throw new ArgumentException("context");
                LogUserAction("create", ctx.UserId, item.Id);
            }
        }

        /// <summary>
        /// Users the is not allowed.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool UserIsNotAllowed(string actionName, int userId, int id)
        {
            // todo use any injected dal to find out if the user can do the action 
            return false;
        }


        /// <summary>
        /// Logs the user action.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="id">The identifier.</param>
        private void LogUserAction(string actionName, int userId, int? id = null)
        {
            // todo use any injected dal to log the user action 
        }
    }

}
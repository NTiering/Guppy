

namespace Specimen.Contracts.Services
{

    using System;
    using System.Collections.Generic;
    using Guppy.Contracts;
    using Specimen.Contracts.DataModels;

    /// <summary>
    /// Example of a more typical service
    /// </summary>
    /// <seealso cref="Guppy.Contracts.IService{Specimen.Contracts.DataModels.OrderDataModel}" />
    public interface IOrderService : IService<OrderDataModel>
    {
        /// <summary>
        /// Gets Stock items in stock with name starting with 'Name'
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IEnumerable<OrderDataModel> GetAllOnDeliveryDate(DateTime deliverDate, IModelContext context = null);
    }

}
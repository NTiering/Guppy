namespace Specimen.Contracts.Dals
{
    using Guppy.Contracts;
    using DataModels;
    using System;
    using System.Collections.Generic;

    public interface IOrderDal : IDal<OrderDataModel>
    {
        /// <summary>
        /// Gets all by delivery date.
        /// </summary>
        /// <param name="deliverDate">The deliver date.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IEnumerable<OrderDataModel> GetAllOnDeliveryDate(DateTime deliverDate, IModelContext context = null);
    }
}

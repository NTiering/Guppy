using Guppy.Contracts;
using Specimen.Contracts.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specimen.Contracts.Services
{
    /// <summary>
    /// Example of a more typical service
    /// </summary>
    /// <seealso cref="Guppy.Contracts.IService{Specimen.Contracts.DataModels.ProductDataModel}" />
    public interface IProductService : IService<ProductDataModel>
    {
        /// <summary>
        /// Gets Stock items in stock with name starting with 'Name'
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IEnumerable<ProductDataModel> GetAllInStockByName(string name, IModelContext context = null);
    }

}

namespace Specimen.Contracts.DataModels
{
    using Guppy.Contracts.Models;

    public class ProductDataModel : IDataModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is unknown to the data access layer (DAL).
        /// </summary>
        public bool IsNew
        {
            get
            {
                return (Id == 0);
            }
        }

        public bool InStock { get; set; }

        public string Name { get; set; } 
    }

}
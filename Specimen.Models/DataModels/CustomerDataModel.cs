namespace Specimen.Contracts.DataModels
{   
    using Guppy.Contracts.Models;

    public class CustomerDataModel : IDataModel
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

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}

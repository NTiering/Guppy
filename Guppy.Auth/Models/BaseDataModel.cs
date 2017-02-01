namespace Guppy.Auth.Models
{   
    using Guppy.Contracts.Models;

    public abstract class BaseDataModel : IDataModel
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
            get { return Id == 0; } 
        }
    }

}
namespace Guppy.Contracts.Models
{

    public partial interface IDataModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is unknown to the data access layer (DAL).
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        bool IsNew { get; }
    }
}

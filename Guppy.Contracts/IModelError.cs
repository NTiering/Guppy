namespace Guppy.Contracts
{
    public partial interface IModelError
    {
        /// <summary>
        /// Gets the property name of the error.
        /// </summary>
        /// <value>
        /// The property.
        /// </value>
        string Property { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        string ErrorMessage { get; }
    }
}
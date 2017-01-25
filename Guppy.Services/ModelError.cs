namespace Guppy.Services
{
    using Guppy.Contracts;

    class ModelError : IModelError
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets the property name of the error.
        /// </summary>
        /// <value>
        /// The property.
        /// </value>
        public string Property { get; set; }
    }

}
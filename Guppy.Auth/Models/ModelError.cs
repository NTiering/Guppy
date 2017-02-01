namespace Guppy.Auth.Models
{
    using Guppy.Contracts;

    public class ModelError : IModelError
    {
        public string ErrorMessage { get; set; }

        public string Property { get; set; }
    }

}
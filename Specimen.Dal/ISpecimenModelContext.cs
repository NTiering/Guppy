
namespace Specimen.Dal
{
    using Guppy.Contracts;

    /// <summary>
    /// Example of how Imodel context can be extended to include user details
    /// </summary>
    public interface ISpecimenModelContext : IModelContext
    { 
        int UserId { get; set; }
    }
}

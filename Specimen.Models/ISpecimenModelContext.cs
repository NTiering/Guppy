using Guppy.Contracts;

namespace Specimen.Contracts
{
    public interface ISpecimenModelContext : IModelContext
    {
        int UserId { get; set; }
    }
}

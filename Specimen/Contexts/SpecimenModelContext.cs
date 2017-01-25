using Specimen.Dal;


namespace Specimen.Contexts
{
    /// <summary>
    /// Example model context 
    /// </summary>
    /// <seealso cref="Specimen.Dal.ISpecimenModelContext" />
    class SpecimenModelContext : ISpecimenModelContext
    {
        public int UserId { get; set; }
    }
}

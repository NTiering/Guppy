namespace Guppy.Auth.Contracts.Model
{
    using Guppy.Contracts;
    using Models;

    public interface IAuthModelContext : IModelContext
    {
        AccountDataModel CurrentUser { get; set; }
    }
}

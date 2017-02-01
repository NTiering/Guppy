namespace Auth.Contexts
{
    using Guppy.Auth.Contracts.Model;
    using Guppy.Auth.Models;

    class AuthModelContext : IAuthModelContext
    {
        public AccountDataModel CurrentUser { get; set; }
    }
}

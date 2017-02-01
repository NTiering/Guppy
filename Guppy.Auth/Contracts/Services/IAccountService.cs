namespace Guppy.Auth.Contracts.Services
{
    using Guppy.Contracts;
    using Models;

    public interface IAccountService : IService<AccountDataModel>
    {
        /// <summary>
        /// Finds the by username password.
        /// </summary>
        AccountDataModel FindByUsernamePassword(string username, string password, IModelContext context = null);

        /// <summary>
        /// Finds the by username.
        /// </summary>
        AccountDataModel FindByUsername(string username, IModelContext context = null);

        /// <summary>
        /// Gets or sets the set as logged in.
        /// </summary>
        AccountDataModel SetAsLoggedIn(string username, IModelContext context = null);

        /// <summary>
        /// Sets account as locked out.
        /// </summary>
        AccountDataModel SetAsLockedOut(string username, int hours = 24, IModelContext context = null);

        /// <summary>
        /// Determines whether the specified account identifier has right.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="rightName">Name of the right.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <c>true</c> if the specified account identifier has right; otherwise, <c>false</c>.
        /// </returns>
        bool HasRight(int accountId, string rightName , IModelContext context = null);
    }
}

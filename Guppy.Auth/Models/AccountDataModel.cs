namespace Guppy.Auth.Models
{
    using System;

    public class AccountDataModel : BaseDataModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the locked out until.
        /// </summary>
        public DateTime? LockedOutUntil { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the loggin attempts.
        /// </summary>
        public int LoginAttempts { get; set; }

        /// <summary>
        /// Gets or sets the last logged in.
        /// </summary>
        public DateTime? LastLoggedIn { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is locked out.
        /// </summary>
        public bool IsLockedOut
        {
            get
            {
                return (LockedOutUntil.HasValue && LockedOutUntil > DateTime.Now);
            }
        }
    }
}

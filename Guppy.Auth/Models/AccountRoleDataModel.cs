namespace Guppy.Auth.Models
{    
    public class AccountRoleDataModel : BaseDataModel
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }
    }

}
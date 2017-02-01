namespace Guppy.Auth.Models
{
    public class LogDataModel : BaseDataModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the subject identifier.
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the subject descriptor.
        /// </summary>
        public string SubjectDescriptor { get; set; }

        /// <summary>
        /// Gets or sets the action descriptor.
        /// </summary>
        public string ActionDescriptor { get; set; }

    }
}
namespace Guppy.Contracts
{
    using System;

    public partial interface IRegisterClient
    {
        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="named">The named.</param>
        void Register(Type @interface, Type instance, string named = "");

        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="named">The named.</param>
        void Register(Type @interface, object instance, string named = "");


    }
}

namespace Guppy.TestHarness
{
    using Contracts;
    using Ninject;
    using System;

    public class ServiceTestHarness : IRegisterClient
    { 
        public IKernel Kernel = new StandardKernel();

        /// <summary>
        /// Overrides the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        public void Override<T>(object o, string name = "")
        {
            Kernel.Unbind<T>();
            Register(typeof(T), o, name);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(string name = "")
        {
            return String.IsNullOrWhiteSpace(name) ?
                Kernel.Get<T>() :
                Kernel.Get<T>(name);
        }

        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="named">The named.</param>
        public void Register(Type @interface, object instance, string named = "")
        {
            if (String.IsNullOrWhiteSpace(named))
            {
                Kernel.Bind(@interface).ToConstant(instance);
            }
            else
            {
                Kernel.Bind(@interface).ToConstant(instance).Named(named);
            }
        }

        /// <summary>
        /// Registers the specified interface.
        /// </summary>
        /// <param name="interface">The interface.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="named">The named.</param>
        public void Register(Type @interface, Type instance, string named = "")
        {
            if (String.IsNullOrWhiteSpace(named))
            {
                Kernel.Bind(@interface).To(instance);
            }
            else
            {
                Kernel.Bind(@interface).To(instance).Named(named);
            }
        }
    }
}

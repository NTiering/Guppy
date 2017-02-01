using Ninject;
using Guppy.Contracts;
using System;
namespace Auth.IoC
{
    class NinjectRegisterClient : IRegisterClient
    {
        public IKernel Kernel = new StandardKernel();

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(string name = "")
        {
            return String.IsNullOrWhiteSpace(name) ?
                Kernel.Get<T>():
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

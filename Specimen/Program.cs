namespace Specimen
{
    using Contexts;
    using Contracts.DataModels;
    using Contracts.Services;
    using Guppy.Contracts;
    using IoC;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // using ninject to implement IoC , could use any provider 
            var registerClient = new NinjectRegisterClient();
            // we could use ninject directly to get instances, handy for MVC intergration 
            // registerClient.Kernel.Get<IService<CustomerDataModel>>();


            // register all services we need 
            Services.Register.RegisterTypes(registerClient);

            // register all dals ('Data access layer') we need             
            Dal.Register.RegisterTypes(registerClient);

            Console.WriteLine("Examples of how to use Guppy to build reuasable & loosly coupled services. Step though the service calls to see how they are put together");
            WaitForKeyPress();

            Console.WriteLine("build and execute a vanila service");
            Ex1(registerClient);
            WaitForKeyPress();

            Console.WriteLine("build and execute a service with a non (CRUD) standard method");
            Ex2(registerClient);
            WaitForKeyPress();

            Console.WriteLine("build and execute a service with a non standard method that can call a stored proc");
            Ex3(registerClient);
            WaitForKeyPress();

            Console.WriteLine("build and execute a service with a non standard method that can call a stored proc and log the action");
            Ex4(registerClient);
            WaitForKeyPress();


            Console.WriteLine("build and execute a service and check and log the user who started the action");
            Ex5(registerClient);

            WaitForKeyPress();
        }

        
        /// <summary>
        /// build and execute a vanila service
        /// </summary>
        /// <param name="registerClient">The register client.</param>
        private static void Ex1(NinjectRegisterClient registerClient)
        {
            List<IModelError> errors;
            var customerService = registerClient.Get<IService<CustomerDataModel>>();
            customerService.TrySave(new CustomerDataModel(), out errors);
            errors.ForEach(x => Console.WriteLine(x.Property + " > " + x.ErrorMessage));           
        }

        /// <summary>
        /// build and execute a service with a non (CRUD) standard method
        /// </summary>
        /// <param name="registerClient">The register client.</param>
        private static void Ex2(NinjectRegisterClient registerClient)
        {
            var productService = registerClient.Get<IProductService>();
            var pResults = productService.GetAllInStockByName("cart");
            pResults.ToList().ForEach(x => Console.WriteLine(x.Name));
        }

        /// <summary>
        /// build and execute a service with a non standard method that can call a stored proc
        /// </summary>
        /// <param name="registerClient">The register client.</param>
        private static void Ex3(NinjectRegisterClient registerClient)
        {
            var orderService = registerClient.Get<IOrderService>();
            var results = orderService.GetAllOnDeliveryDate(DateTime.Now, new SpecimenModelContext { UserId = 99 }); // added a context, this can be anything implementing IModelContext
            results.ToList().ForEach(x => Console.WriteLine("Order " + x.Id + " delivered today"));
        }

        /// <summary>
        /// build and execute a service with a non standard method that can call a stored proc and log the action
        /// </summary>
        /// <param name="registerClient">The register client.</param>
        /// <returns></returns>
        private static void Ex4(NinjectRegisterClient registerClient)
        {
            var loggedService = registerClient.Get<ILoggedOrderService>();
            var loggedResults = loggedService.GetAllOnDeliveryDate(DateTime.Now, new SpecimenModelContext { UserId = 99 });
            loggedResults.ToList().ForEach(x => Console.WriteLine("Order " + x.Id + " delivered today and search logged"));
        }

        /// <summary>
        /// build and execute a service and check and log the user who started the action
        /// </summary>
        /// <param name="registerClient">The register client.</param>
        private static void Ex5(NinjectRegisterClient registerClient)
        {
            var loggedService = registerClient.Get<ILoggedOrderService>();
            var order = loggedService.Get(19, new SpecimenModelContext { UserId = 44 }); // get order 19 , requested by user 44
            Console.WriteLine("order " + order.Id + " found");
        }

        private static void WaitForKeyPress()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}

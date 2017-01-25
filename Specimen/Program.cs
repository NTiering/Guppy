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
            /// registerClient.Kernel.Get<IService<CustomerDataModel>>();
            

            // register all services we need 
            Services.Register.RegisterTypes(registerClient);

            // register all dals ('Data access layer') we need             
            Dal.Register.RegisterTypes(registerClient);

            Console.WriteLine("Examples of how to use Guppy to build reuasable & loosly coupled services. Step though the service calls to see how they are put together");
            
            WaitForKeyPress();

            var errors = new List<IModelError>();

            Console.WriteLine("build and execute a vanila service");
                 
            var customerService = registerClient.Get<IService<CustomerDataModel>>();
            customerService.TrySave(new CustomerDataModel(), out errors);
            errors.ForEach(x => Console.WriteLine(x.Property + " > " + x.ErrorMessage));

            WaitForKeyPress();
           
            Console.WriteLine("build and execute a service with a non (CRUD) standard method");

            var productService = registerClient.Get<IProductService>();
            var productResults = productService.GetAllInStockByName("cart");
            productResults.ToList().ForEach(x => Console.WriteLine(x.Name));

            WaitForKeyPress();

            Console.WriteLine("build and execute a service with a non standard method that can call a stored proc");
            var orderService = registerClient.Get<IOrderService>();
            var orderResults = orderService.GetAllOnDeliveryDate(DateTime.Now, new SpecimenModelContext { UserId = 99 }); // added a context, this can be anything derived from IModelContext
            orderResults.ToList().ForEach(x => Console.WriteLine("Order " + x.Id + " delivered today"));

            WaitForKeyPress();

            Console.WriteLine("build and execute a service with a non standard method that can call a stored proc and log the action");

            var loggedService = registerClient.Get<ILoggedOrderService>();
            var loggedResults = loggedService.GetAllOnDeliveryDate(DateTime.Now, new SpecimenModelContext { UserId = 99 });
            orderResults.ToList().ForEach(x => Console.WriteLine("Order " + x.Id + " delivered today and search logged"));

            WaitForKeyPress();
          

            Console.WriteLine("build and execute a service and check and log the user who started the action");

            loggedService = registerClient.Get<ILoggedOrderService>();
            var order = loggedService.Get(19, new SpecimenModelContext { UserId = 99});
            Console.WriteLine("order " + order.Id + " found");

            WaitForKeyPress();
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

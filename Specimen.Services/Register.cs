namespace Specimen.Services
{
    using Contracts.DataModels;
    using Contracts.Services;
    using FluentValidation;
    using Guppy.Contracts;
    using Validators;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {
            // register all types to be used outside of the project here
            registerClient.Register(typeof(IService<CustomerDataModel>), typeof(CustomerService));
            registerClient.Register(typeof(IProductService), typeof(ProductService));

            registerClient.Register(typeof(IOrderService), typeof(OrderService));
            registerClient.Register(typeof(IService<OrderDataModel>), typeof(OrderService));
            registerClient.Register(typeof(ILoggedOrderService), typeof(LoggedOrderService));

            // validators
            registerClient.Register(typeof(IValidator<CustomerDataModel>), typeof(CustomerValidator));
            registerClient.Register(typeof(IValidator<ProductDataModel>), typeof(ProductValidator));
            registerClient.Register(typeof(IValidator<OrderDataModel>), typeof(OrderValidator));



        }
    }
}
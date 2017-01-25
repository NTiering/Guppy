namespace Specimen.Dal
{
    using Contracts.Dals;
    using Contracts.DataModels;
    using Guppy.Contracts;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {
            // register all types to be used outside of the project here           
            registerClient.Register(typeof(IDal<CustomerDataModel>), typeof(CustomerDal));
            registerClient.Register(typeof(IDal<ProductDataModel>), typeof(ProductDal));
            registerClient.Register(typeof(IOrderDal), typeof(OrderDal));
        }
    }
}
namespace Guppy.Auth
{
    using Contracts.Dal;
    using Contracts.Services;
    using Contracts.Validator;
    using Dal;
    using Guppy.Contracts;
    using Models;
    using Services;
    using Validator;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {
            // dals            
            registerClient.Register(typeof(IDal<AccountDataModel>), typeof(AccountDal));
            registerClient.Register(typeof(IDal<AccountRoleDataModel>), typeof(AccountRoleDal));
            registerClient.Register(typeof(IDal<LogDataModel>), typeof(LogDal));
            registerClient.Register(typeof(IDal<RightDataModel>), typeof(RightDal));
            registerClient.Register(typeof(IDal<RightRoleDataModel>), typeof(RightRoleDal));
            registerClient.Register(typeof(IDal<RoleDataModel>), typeof(RoleDal));
            registerClient.Register(typeof(IRoleDal), typeof(RoleDal));
            registerClient.Register(typeof(IAccountDal), typeof(AccountDal));

            // validators 
            registerClient.Register(typeof(IAccountValidator), typeof(AccountValidator));
            registerClient.Register(typeof(IRightValidator), typeof(RightValidator));
            registerClient.Register(typeof(IRoleValidator), typeof(RoleValidator));


            registerClient.Register(typeof(IService<AccountDataModel>), typeof(AccountService));
            registerClient.Register(typeof(IService<RightDataModel>), typeof(RightService));
            registerClient.Register(typeof(IService<RoleDataModel>), typeof(RoleService));

            registerClient.Register(typeof(IAccountService), typeof(AccountService));
            registerClient.Register(typeof(IRightService), typeof(RightService));
            registerClient.Register(typeof(IRoleService), typeof(RoleService));


            // validators
           // registerClient.Register(typeof(IValidator<>), typeof());




        }
    }
}
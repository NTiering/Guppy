using Auth.Contexts;
using Auth.IoC;
using Guppy.Auth.Contracts.Services;
using Guppy.Auth.Models;
using Guppy.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            // using ninject to implement IoC , could use any provider 
            var registerClient = new NinjectRegisterClient();

            // register all services, dals and validators we need 
            Guppy.Auth.Register.RegisterTypes(registerClient);

            // make all services we will need 
            var accountService = registerClient.Get<IAccountService>();
            var roleService = registerClient.Get<IRoleService>();
            var rightsService = registerClient.Get<IRightService>();

            // holde for erros
            List<IModelError> errors;



            // make a user account & read it back                                     
            accountService.TrySave(
                new AccountDataModel
                {
                    Username = "userAdmin@example.com",
                    Password = "0123456789"
                },
            out errors,
            new AuthModelContext
            {
                CurrentUser = new AccountDataModel
                {
                    Username = "admin@admin",
                    Id = -1
                }
            }
            );
            var userAccount = accountService.Get(x => x.Username == "userAdmin@example.com");

            // make role "User admin"
            roleService.TrySave(new RoleDataModel { Name = "UserAdmin" }, out errors);

            // save some rights ...
            rightsService.TrySave(new RightDataModel { Name = "user-add" }, out errors);
            rightsService.TrySave(new RightDataModel { Name = "user-remove" }, out errors);
            rightsService.TrySave(new RightDataModel { Name = "ser-edit" }, out errors);

            rightsService.TrySave(new RightDataModel { Name = "order-add" }, out errors);
            rightsService.TrySave(new RightDataModel { Name = "order-remove" }, out errors);
            rightsService.TrySave(new RightDataModel { Name = "order-edit" }, out errors);

            // oops update some right name
            var oldRight = rightsService.Get(x => x.Name == "ser-edit");
            oldRight.Name = "user-edit";
            rightsService.TrySave(oldRight, out errors);

            // add all user rights to "UserAdmin" role
            var userAdminRole = roleService.Get(x => x.Name == "UserAdmin");
            foreach (var right in rightsService.GetAll(x => x.Name.StartsWith("user")))
            {
                roleService.TryAddRightToRole(userAdminRole.Id, right.Id);
            }


            // add role "UserAdmin" to our user 
            roleService.TryAddRolesToAccountId(userAccount.Id, userAdminRole.Id);

            // get our account rights (3 in total)
            var rights = rightsService.GetRightsByAccountId(userAccount.Id);

            // check if out Account has a right
            var canAddUser = accountService.HasRight(userAccount.Id, "user-add");
            var canEditUser = accountService.HasRight(userAccount.Id, "user-edit");
            var canAddOrder = accountService.HasRight(userAccount.Id, "order-add");
        }
    }
}

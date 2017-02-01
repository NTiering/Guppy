using Guppy.Auth.Contracts.Services;
using System;
using System.Collections.Generic;
using Guppy.Auth.Models;
using Guppy.Contracts;
using Guppy.Services;
using Guppy.Auth.Contracts.Validator;
using System.Linq;

namespace Guppy.Auth.Services
{
    class RightService : BaseService<RightDataModel>, IRightService
    {
        private IDal<AccountRoleDataModel> accountRoleDal;
        private IDal<RightDataModel> rightDal;
        private IDal<RightRoleDataModel> rightRoleDal;
        private IDal<RoleDataModel> roleDal;
        private IRightValidator validator;

        public RightService(IDal<RightDataModel> dal, IDal<RoleDataModel> roleDal, IDal<RightRoleDataModel> rightRoleDal, IDal<RightDataModel> rightDal, IDal<AccountRoleDataModel> accountRoleDal ,IRightValidator validator) : base(dal)
        {
            this.validator = validator;
            this.roleDal = roleDal;
            this.rightRoleDal = rightRoleDal;
            this.rightDal = rightDal;
            this.accountRoleDal = accountRoleDal;
        }

        public IEnumerable<RightDataModel> GetRightsByAccountId(int accountId, IModelContext context = null)
        {
            var rtn = new List<RightDataModel>();

            var roleIds = accountRoleDal
                .GetAll(x => x.AccountId == accountId, context)
                .Select(x => x.RoleId);

            foreach (var roleId in roleIds)
            {
                rtn.AddRange(
                    rightRoleDal.GetAll(x => x.RoleId == roleId, context)
                    .Select(x => rightDal.Get(x.RightId, context)));
            }

            return rtn;
        }

        public IEnumerable<RightDataModel> GetRightsByRoleId(int roleId, IModelContext context = null)
        {            
            if (RoleExists(roleId, context) == false) return Enumerable.Empty<RightDataModel>();
            var rights = rightRoleDal.GetAll(x => x.RoleId == roleId, context).Select(x => rightDal.Get(x.RightId, context)).ToList();
            return rights;
        }

       
        protected override bool IsValid(RightDataModel item, List<IModelError> errors)
        {
            return validator.IsValid(item, errors);
        }

        /// <summary>
        /// Roles exists ?
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private bool RoleExists(int roleId, IModelContext context)
        {
            return roleDal.Get(roleId, context) != null;
        }        
    }
}

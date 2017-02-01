namespace Guppy.Auth.Services
{
    using Models;
    using Guppy.Services;
    using Contracts.Services;
    using Guppy.Contracts;
    using System.Collections.Generic;
    using System;
    using Contracts.Validator;
    using System.Linq;

    class RoleService : BaseService<RoleDataModel>, IRoleService
    {
        private IDal<AccountDataModel> accountDal;
        private IDal<AccountRoleDataModel> accountRoleDal;
        private IDal<RoleDataModel> roleDal;
        private IRoleValidator validator;
        private IDal<RightRoleDataModel> rightRoleDal;
        private IDal<RightDataModel> rightDal;

        public RoleService(IDal<RoleDataModel> dal,IDal<AccountDataModel> accountDal, IDal<AccountRoleDataModel> accountRoleDal, IDal<RoleDataModel> roleDal, IDal<RightDataModel> rightDal, IDal<RightRoleDataModel>  rightRoleDal, IRoleValidator validator) : base(dal)
        {
            this.validator = validator;
            this.accountRoleDal = accountRoleDal;
            this.roleDal = roleDal;
            this.rightDal = rightDal;
            this.rightRoleDal = rightRoleDal;
            this.accountDal = accountDal; 
        }

        public IEnumerable<RoleDataModel> GetRolesByAccountId(int accountId)
        {
            var rtn = new List<RoleDataModel>();
            foreach (var roleId in accountRoleDal.GetAll(x => x.AccountId == accountId, null).Select(x=>x.RoleId))
            {
                rtn.Add(roleDal.Get(roleId,null));
            }
            return rtn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <returns></returns>
        public bool TryRemoveRightFromRole(int roleId, int rightId, IModelContext context = null)
        {
            if (RoleExists(roleId, context) == false) return false;  
            if (RightExists(rightId, context) == false) return false;

            var link = GetLink(roleId, rightId, context);
            if (link == null) return false;
            rightRoleDal.Delete(link.Id, context);
            return true;
        }                


        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <returns></returns>
        public bool TryAddRightToRole(int roleId, int rightId, IModelContext context = null)
        {
            if (RoleExists(roleId, context) == false) return false;
            if (RightExists(rightId, context) == false) return false;

            var link = GetLink(roleId, rightId, context);
            if (link != null) return false;
            rightRoleDal.Create(new RightRoleDataModel { RoleId = roleId, RightId = rightId }, context);
            return true;
        }
                

        /// <summary>
        /// Tries the add roles to account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public bool TryAddRolesToAccountId(int accountId, params int[] roleIds)
        {
            var account = accountDal.Get(accountId,null);
            if (account == null) return false;

            foreach (var roleId in roleIds)
            {
                var role = roleDal.Get(roleId, null);
                if (role != null)
                {
                    accountRoleDal.Create(new AccountRoleDataModel { AccountId = accountId, RoleId = role.Id },null);
                }
            }

            return true;

        }   

        /// <summary>
        /// Tries the remove roles from account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public bool TryRemoveRolesFromAccountId(int accountId, params int[] roleIds)
        {
            var account = accountDal.Get(accountId, null);
            if (account == null) return false;

            foreach (var roleId in roleIds)
            {
                Func<AccountRoleDataModel, bool> filter = x => { return x.AccountId == accountId && x.RoleId == roleId; };
                var ar = accountRoleDal.Get(filter,null);
                if (ar != null)
                {
                    accountRoleDal.Delete(ar.Id, null);
                }
            }

            return true;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValid(RoleDataModel item, List<IModelError> errors)
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

        /// <summary>
        /// Rights exists ?
        /// </summary>
        /// <param name="rightId">The right identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private bool RightExists(int rightId, IModelContext context)
        {
            return rightDal.Get(rightId, context) != null;
        }

        /// <summary>
        /// Gets the link.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="rightId">The right identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private RightRoleDataModel GetLink(int roleId, int rightId, IModelContext context)
        {
            return rightRoleDal.Get(x => x.RightId == rightId && x.RoleId == roleId, context);
        }
    }

}
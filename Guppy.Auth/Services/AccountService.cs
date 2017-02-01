namespace Guppy.Auth.Services
{
    using Models;
    using Guppy.Services;
    using System.Collections.Generic;
    using Guppy.Contracts;
    using Contracts.Dal;
    using Contracts.Validator;
    using Helpers;
    using Contracts.Model;
    using Contracts.Services;
    using System;
    using System.Linq;

    class AccountService : BaseService<AccountDataModel>, IAccountService
    {
        private IAccountDal accountDal;
        private IDal<LogDataModel> logDal;
        private IAccountValidator validator;
        private IDal<RoleDataModel> roleDal;
        private IDal<AccountRoleDataModel> accountRoleDal;
        private IDal<RightRoleDataModel> rightRoleDal;
        private IDal<RightDataModel> rightDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="dal">The dal.</param>
        /// <param name="logDal">The log dal.</param>
        /// <param name="validator">The validator.</param>
        public AccountService(IDal<AccountDataModel> dal, IDal<RightDataModel> rightDal, IDal<LogDataModel> logDal, IDal<RoleDataModel> roleDal, IDal<AccountRoleDataModel> accountRoleDal, IDal<RightRoleDataModel> rightRoleDal,IAccountValidator validator) : base(dal)
        {
            this.logDal = logDal;
            accountDal = (IAccountDal) dal;
            this.roleDal = roleDal;
            this.rightDal = rightDal;
            this.accountRoleDal = accountRoleDal;
            this.rightRoleDal = rightRoleDal;
            this.validator = validator;
        }

        /// <summary>
        /// Tries to save the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool TrySave(AccountDataModel item, out List<IModelError> errors, IModelContext context = null)
        {           
            LogSave(item, context.ToAuthModelContext());
            item.Password = item.Password.OneWayHash();
            return base.TrySave(item, out errors, context);
        }

        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool TryDelete(int id, IModelContext context = null)
        {
            LogDelete(id, context.ToAuthModelContext());
            return base.TryDelete(id, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AccountDataModel FindByUsernamePassword(string username, string password, IModelContext context = null)
        {
            Func<AccountDataModel, bool> filter = (x) => { return x.Username == username && x.Password == password.OneWayHash(); };
            return dal.Get(filter,null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public AccountDataModel FindByUsername(string username, IModelContext context = null)
        {
            Func<AccountDataModel, bool> filter = (x) => { return x.Username == username; };
            return dal.Get(filter, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public AccountDataModel SetAsLoggedIn(string username, IModelContext context = null)
        {
            var model = FindByUsername(username);
            if (model == null) return null;
            model.LoginAttempts = 0;
            model.LastLoggedIn = DateTime.Now;
            dal.Update(model, null);
            return model;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public AccountDataModel SetAsLockedOut(string username, int hours, IModelContext context = null)
        {
            var model = FindByUsername(username);
            if (model == null) return null;
            model.LockedOutUntil = DateTime.Now.AddHours(hours);
            dal.Update(model, null);
            return model;

        }           

        /// <summary>
        /// Logs the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authModelContext">The authentication model context.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LogDelete(int id, IAuthModelContext context)
        {
            logDal.Create(
               new LogDataModel
               {
                   ActionDescriptor = "Delete",
                   UserId = context.CurrentUser.Id,
                   SubjectDescriptor = "Account",
                   SubjectId = id
               }, context);
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValid(AccountDataModel item, List<IModelError> errors)
        {
            return validator.IsValid(item, errors);
        }

        /// <summary>
        /// Logs the save.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        private void LogSave(AccountDataModel item, IAuthModelContext context)
        {
            var actionDescriptor = item.IsNew ? "Created " + item.Username : "Update";

            logDal.Create(
               new LogDataModel
               {
                   ActionDescriptor = actionDescriptor,
                   UserId = context.CurrentUser.Id,
                   SubjectDescriptor = "Account",
                   SubjectId = item.Id
               }, context);
        }

        /// <summary>
        /// Determines whether the specified account identifier has right.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="rightName">Name of the right.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <c>true</c> if the specified account identifier has right; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRight(int accountId, string rightName, IModelContext context = null)
        {
            var right = this.rightDal.Get(x => x.Name == rightName, context);
            if (right == null) return false; // right not found 
            var roles = rightRoleDal.GetAll(x => x.RightId == right.Id, context).Select(x=>x.RoleId);
            if (roles.Any() == false) return false; // right not assigned to any role
            var rtn = this.accountRoleDal.GetAll(x => x.AccountId == accountId && roles.Any(y => y == x.RoleId),context);

            return rtn.Any();
        }
    }
}

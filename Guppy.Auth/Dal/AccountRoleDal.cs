namespace Guppy.Auth.Dal
{
    using Models;
    using Guppy.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class AccountRoleDal : IDal<AccountRoleDataModel>
    {
        private static List<AccountRoleDataModel> fakeDb = new List<AccountRoleDataModel>();

        public void Create(AccountRoleDataModel item, IModelContext context)
        {
            item.Id = (fakeDb.Count() + 1);
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }

        public AccountRoleDataModel Get(Func<AccountRoleDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public AccountRoleDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<AccountRoleDataModel> GetAll(Func<AccountRoleDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(AccountRoleDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }

}
namespace Guppy.Auth.Dal
{
    using Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Contracts.Dal;
    using Guppy.Contracts;

    class AccountDal : IDal<AccountDataModel> , IAccountDal
    {
        private static List<AccountDataModel> fakeDb = new List<AccountDataModel>();

        public void Create(AccountDataModel item, IModelContext context)
        {
            item.Id = (fakeDb.Count()+1);
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x=>x.Id == id);
        }

        public AccountDataModel Get(Func<AccountDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public AccountDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x=>x.Id == id);
        }

        public IQueryable<AccountDataModel> GetAll(Func<AccountDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(AccountDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }
}

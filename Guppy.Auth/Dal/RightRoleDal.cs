namespace Guppy.Auth.Dal
{
    using Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Guppy.Contracts;

    class RightRoleDal : IDal<RightRoleDataModel>
    {
        private static List<RightRoleDataModel> fakeDb = new List<RightRoleDataModel>();

        public void Create(RightRoleDataModel item, IModelContext context)
        {
            item.Id = (fakeDb.Count() + 1);
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }

        public RightRoleDataModel Get(Func<RightRoleDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public RightRoleDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<RightRoleDataModel> GetAll(Func<RightRoleDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(RightRoleDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }

}
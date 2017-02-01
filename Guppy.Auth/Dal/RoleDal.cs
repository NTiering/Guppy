namespace Guppy.Auth.Dal
{
    using Models;   
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Guppy.Contracts;
    using Contracts.Dal;

    class RoleDal : IDal<RoleDataModel> , IRoleDal
    {
        private static List<RoleDataModel> fakeDb = new List<RoleDataModel>();

        public void Create(RoleDataModel item, IModelContext context)
        {
            item.Id = (fakeDb.Count() + 1);
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }

        public RoleDataModel Get(Func<RoleDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public RoleDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<RoleDataModel> GetAll(Func<RoleDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(RoleDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }

}
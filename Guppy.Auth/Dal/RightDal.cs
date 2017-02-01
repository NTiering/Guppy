namespace Guppy.Auth.Dal
{
    using Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Guppy.Contracts;

    class RightDal : IDal<RightDataModel>
    {
        private static List<RightDataModel> fakeDb = new List<RightDataModel>();

        public void Create(RightDataModel item, IModelContext context)
        {
            item.Id = (fakeDb.Count() + 1);
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }

        public RightDataModel Get(Func<RightDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public RightDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<RightDataModel> GetAll(Func<RightDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(RightDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }

}
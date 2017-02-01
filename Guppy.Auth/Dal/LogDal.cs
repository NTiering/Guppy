namespace Guppy.Auth.Dal
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Guppy.Contracts;

    class LogDal : IDal<LogDataModel>
    {
        private static List<LogDataModel> fakeDb = new List<LogDataModel>();

        public void Create(LogDataModel item, IModelContext context)
        {
            item.Id = (fakeDb.Count() + 1);
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }

        public LogDataModel Get(Func<LogDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public LogDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<LogDataModel> GetAll(Func<LogDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(LogDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }

}
namespace Specimen.Dal
{
    using Guppy.Contracts;
    using Contracts.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomerDal : IDal<CustomerDataModel>
    {
        private List<CustomerDataModel> fakeDb = new List<CustomerDataModel>();
         
        public void Create(CustomerDataModel item, IModelContext context)
        {
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x=>x.Id == id);
        }

        public CustomerDataModel Get(Func<CustomerDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public CustomerDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x=>x.Id == id);
        }

        public IQueryable<CustomerDataModel> GetAll(Func<CustomerDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(CustomerDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }
}

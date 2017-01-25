
namespace Specimen.Dal
{
    using Guppy.Contracts;
    using Contracts.DataModels;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class ProductDal : IDal<ProductDataModel>
    {
        private List<ProductDataModel> fakeDb = new List<ProductDataModel>();

        public ProductDal()
        {
            fakeDb.Add(new ProductDataModel { InStock = true, Name = "cartridge pen" });
            fakeDb.Add(new ProductDataModel { InStock = true, Name = "cart , red" });
        }

        public void Create(ProductDataModel item, IModelContext context)
        {
            fakeDb.Add(item);
        }

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }

        public ProductDataModel Get(Func<ProductDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public ProductDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<ProductDataModel> GetAll(Func<ProductDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }

        public void Update(ProductDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
    }

}
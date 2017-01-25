
namespace Specimen.Dal
{
    using Guppy.Contracts;
    using Contracts.DataModels;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Contracts.Dals;

   class OrderDal : IOrderDal
    {
        private List<OrderDataModel> fakeDb = new List<OrderDataModel>();

        public OrderDal()
        {
            fakeDb.Add(new OrderDataModel { DeliverDate = DateTime.Now, Id = 19 } );
        }

        public IEnumerable<OrderDataModel> GetAllOnDeliveryDate(DateTime deliverDate, IModelContext context = null)
        {
            // this could call an SP
            return fakeDb.Where(x => x.DeliverDate.Date == deliverDate.Date);
        }

        public void Create(OrderDataModel item, IModelContext context)
        {
            fakeDb.Add(item);
        }        

        public void Delete(int id, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == id);
        }
       
        public OrderDataModel Get(Func<OrderDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.FirstOrDefault(filter);
        }

        public OrderDataModel Get(int id, IModelContext context)
        {
            return fakeDb.FirstOrDefault(x => x.Id == id);
        }
       

        public IQueryable<OrderDataModel> GetAll(Func<OrderDataModel, bool> filter, IModelContext context)
        {
            return fakeDb.Where(filter).AsQueryable();
        }
                
      
        public void Update(OrderDataModel item, IModelContext context)
        {
            fakeDb.RemoveAll(x => x.Id == item.Id);
            fakeDb.Add(item);
        }
        
    }

}
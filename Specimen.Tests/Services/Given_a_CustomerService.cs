using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guppy.Contracts;
using Specimen.Contracts.DataModels;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Guppy.TestHarness;

namespace Specimen.Tests.Services
{
    [TestClass]
    public class Given_a_CustomerService
    {

        [TestMethod]
        public void Can_be_constructed()
        {
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Invalid_Customers_Are_Rejected()
        {
            var models = InvalidModels;
            foreach (var key in models.Keys)
            {
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                Assert.IsFalse(result, "Invalid item '" + key + "' was accepted");
            }
        }

        [TestMethod]
        public void Valid_Customers_Are_Saved()
        {
            var models = ValidModels; 
            foreach (var key in models.Keys)
            {
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                Assert.IsTrue(result, "Valid item '" + key + "' was not accepted");
            }
        }

        [TestMethod]
        public void Invalid_Customers_Return_Errors()
        {
            var models = InvalidModels;
            foreach (var key in models.Keys)
            {
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                Assert.IsTrue(errors.Any(), "Invalid item '" + key + "' did not make an error message");
            }
        }

        [TestMethod]
        public void Valid_Customers_Return_No_Errors()
        {
            var models = ValidModels;
            foreach (var key in models.Keys)
            {
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                Assert.IsFalse(errors.Any(), "Valid item '" + key + "' did not made an error message");
            }
        }

        [TestMethod]
        public void Valid_Customers_Dont_Return_Errors()
        {
            var models = InvalidModels; 
            foreach (var key in models.Keys)
            {
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                Assert.IsTrue(errors.Any(), "Invalid item '" + key + "' did not make an error message");
            }
        }

        [TestMethod]
        public void Invalid_Customers_Do_Not_Save()
        {
            var models = InvalidModels;
            foreach (var key in models.Keys)
            {
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                mockDal.Verify(x => x.Create(It.IsAny<CustomerDataModel>(), It.IsAny<IModelContext>()), Times.Never, "Invalid item '" + key + "' was saved");
            }
        }

        [TestMethod]
        public void Valid_Customers_Are_Persisted()
        {
            var count = 0;
            var models = ValidModels;
            foreach (var key in models.Keys)
            {
                count++;
                var model = models[key];
                var errors = new List<IModelError>();
                var result = service.TrySave(model, out errors);

                mockDal.Verify(x => x.Create(It.IsAny<CustomerDataModel>(), It.IsAny<IModelContext>()), Times.Exactly(count), "Valid item '" + key + "' was not saved");
          
            }
        }



        private static Dictionary<string, CustomerDataModel> InvalidModels;
        private static Dictionary<string, CustomerDataModel> ValidModels;

        [ClassInitialize]
        public static void MakeData(TestContext ctx)
        {
            InvalidModels = new Dictionary<string, CustomerDataModel>();
            InvalidModels["null_model"] = null;
            InvalidModels["null_name"] = new CustomerDataModel { Name = null };
            InvalidModels["empty_name"] = new CustomerDataModel { Name = String.Empty };
        
            ValidModels = new Dictionary<string, CustomerDataModel>();
            ValidModels["one_name"] = new CustomerDataModel { Name = "1" };
            ValidModels["string_name"] = new CustomerDataModel { Name = "test " };
        }



        private IService<CustomerDataModel> service;
        private Mock<IDal<CustomerDataModel>> mockDal;

        [TestInitialize]
        public void MakeService()
        {
            mockDal = new Mock<IDal<CustomerDataModel>>();
            var serviceTestHarness = new ServiceTestHarness();

            Specimen.Services.Register.RegisterTypes(serviceTestHarness);
            Specimen.Dal.Register.RegisterTypes(serviceTestHarness);

            // override the customer Dal with our mock dal 
            serviceTestHarness.Override<IDal<CustomerDataModel>>(mockDal.Object);

            // expose our service that now uses the mock dal
            service = serviceTestHarness.Get<IService<CustomerDataModel>>();
        }



    }
}

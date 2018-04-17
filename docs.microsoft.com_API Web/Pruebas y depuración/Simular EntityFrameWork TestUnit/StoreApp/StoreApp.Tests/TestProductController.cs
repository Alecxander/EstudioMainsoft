using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreApp.Models;
using StoreApp.Controllers;
using System.Web.Http.Results;


namespace StoreApp.Tests
{
    [TestClass]
    class TestProductController
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new ProductsController(new TestStoreAppContext());

            var item = GetDemoProduct();

            var result = controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        Product GetDemoProduct()
        {
            return new Product() { Id = 3, Name = "Demo name", Price = 5 };
        }
    }
}

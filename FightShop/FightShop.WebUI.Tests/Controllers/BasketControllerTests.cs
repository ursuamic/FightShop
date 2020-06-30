using System;
using System.Linq;
using System.Web.Mvc;
using FightShop.Core.Contracts;
using FightShop.Core.Models;
using FightShop.Core.ViewModels;
using FightShop.Services;
using FightShop.WebUI.Controllers;
using FightShop.WebUI.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FightShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTests
    {
        [TestMethod]
        public void CanAddBasketItem()
        {
            //setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();

            var httpContext = new MockHttpContext();

            IBasketService basketService = new Basketservice(products, baskets);
            var controller = new BasketController(basketService);
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);
            //basketService.AddToBasket(httpContext, "1");
            
            //Act
            controller.AddToBasket("1");

            Basket basket = baskets.Collection().FirstOrDefault();

            //Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);

        }
        [TestMethod]
        public void CanGetSummaryViewModel()
        {
            //setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();

            products.Insert(new Product() { Id = "1", Price = "10.00" });
            products.Insert(new Product() { Id = "2", Price = "20.00" });

            Basket basket = new Basket();
            basket.BasketItems.Add(new BasketItem() { ProductId = "1", Quantity = 2 });
            basket.BasketItems.Add(new BasketItem() { ProductId = "2", Quantity = 1 });

            baskets.Insert(basket);

            IBasketService basketService = new Basketservice(products, baskets);

            var controller = new BasketController(basketService);
            var httpContext = new MockHttpContext();
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel)result.ViewData.Model;

            //Assert
            //Assert.AreEqual(3, basketSummary.BasketCount);
            //Assert.AreEqual(30.00, basketSummary.BasketTotal);            
        }
    }
}

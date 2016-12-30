using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.Controllers;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.foo() as ViewResult;
            Console.Write(result.ViewName);
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homeController = new HomeController();
            var result = homeController.Contact("I love your bank") as ViewResult;
            Assert.AreEqual("Thanks!", result.ViewBag.TheMessage);

        }
    }
}

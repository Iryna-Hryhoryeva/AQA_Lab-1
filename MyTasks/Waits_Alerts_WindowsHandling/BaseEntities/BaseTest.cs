using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.BaseEntities
{
    public class BaseTest
    {
        [ThreadStatic] private static IWebDriver _driver;
        private static WaitService _waitService;

        [SetUp]
        protected void Setup()
        {
            _driver = new BrowserService().WebDriver;
            _waitService = new WaitService(_driver);
        }

        [TearDown]
        protected void TearDown()
        {
            _driver.Quit();
        }

        protected static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected static WaitService WaitService
        {
            get => _waitService;
        }
    }
}

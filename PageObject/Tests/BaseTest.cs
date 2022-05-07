using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Tests
{
    public class BaseTest
    {
        [ThreadStatic] private static IWebDriver _driver;

        [SetUp]
        protected void Setup()
        {
            _driver = new BrowserService().WebDriver;
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
    }
}

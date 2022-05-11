using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.BaseEntities
{
    public abstract class BasePage
    {
        private const int _waitForPageLoadingTime = 60;
        private static readonly By _numberOfOffersButtonBy = By.CssSelector(".button.button_orange");
        [ThreadStatic] private static IWebDriver _driver;
        private static WaitService _waitService;

        protected abstract void OpenPage();
        protected abstract bool IsPageOpened();

        protected BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            _waitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }

        private void WaitForOpen()
        {
            var secondsCount = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (!isPageOpenedIndicator && secondsCount < (_waitForPageLoadingTime / Configurator.WaitTimeout))
            {
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }

        public static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static WaitService WaitService
        {
            get => _waitService;
        }

        public IWebElement NumberOfOffersButton => WaitService.WaitElementIsVisible(_numberOfOffersButtonBy);
    }
}

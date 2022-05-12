using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public abstract class BasePage
    {
        private const int _waitForPageLoadingTime = 60;
        [ThreadStatic] private static IWebDriver _driver;

        protected abstract void OpenPage();
        protected abstract bool IsPageOpened();

        protected BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;

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

            while (!isPageOpenedIndicator && secondsCount < _waitForPageLoadingTime)
            {
                Thread.Sleep(1000);
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
    }
}

using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Waits_Alerts_WindowsHandling.Services;

public class WaitService
{
    private IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly DefaultWait<IWebDriver> _fluentWait;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
        _fluentWait = new DefaultWait<IWebDriver>(_driver)
        {
            Timeout = TimeSpan.FromSeconds(Configurator.WaitTimeout),
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };

        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public IWebElement WaitElementIsVisible(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitElementExists(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }

    public ReadOnlyCollection<IWebElement> WaitElementsPresent(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
    }
    
    public IWebElement WaitQuickElement(By locator)
    {
        return _fluentWait.Until(driver => driver.FindElement(locator));
    }
    
    public bool WaitForElementToDisappear(By elementBy)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(elementBy));
    }

    public void WaitPageRefreshed(string url)
    {
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(url));
    }
}

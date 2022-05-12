using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages.CheckoutPages;

public class CheckoutPage3 : BasePage
{
    private const string _endPoint = "/checkout-complete.html";
    public IWebElement Title = Driver.FindElement(By.ClassName("title"));
    public IWebElement ThankYouMessage = Driver.FindElement(By.ClassName("complete-header"));
    public IWebElement BackHomeButton = Driver.FindElement(By.CssSelector("#back-to-products"));

    public CheckoutPage3(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + _endPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return BackHomeButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }
}

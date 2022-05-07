using System;
using OpenQA.Selenium;
using PageObject.Buttons;
using PageObject.Services;

namespace PageObject.Pages.CheckoutPages;

public class CheckoutPage3 : BasePage, IContinueButton, IGoBackButton, IHaveCartButton, IHaveBurgerButton,
    IHaveSocialNetworks
{
    private const string _endPoint = "/checkout-complete.html";
    private static readonly By _title = By.ClassName("title");
    private static readonly By _thankYouMessage = By.ClassName("complete-header");
    private static readonly By _backHomeButtonBy = By.CssSelector("#back-to-products");

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

    public IWebElement BackHomeButton = Driver.FindElement(_backHomeButtonBy);
    public IWebElement Title = Driver.FindElement(_title);
    public IWebElement ThankYouMessage = Driver.FindElement(_thankYouMessage);
}

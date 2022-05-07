using System;
using OpenQA.Selenium;
using PageObject.Buttons;
using PageObject.Services;

namespace PageObject.Pages.CheckoutPages;

public class CheckoutPage1 : BasePage, IHaveBurgerButton, IHaveCartButton, IGoBackButton, IHaveSocialNetworks,
    IContinueButton
{
    private const string _endPoint = "/checkout-step-one.html";
    private static readonly By _titleBy = By.ClassName("title");
    private static readonly By _firstName = By.Id("first-name");
    private static readonly By _lastName = By.Id("last-name");
    private static readonly By _postalCode = By.Id("postal-code");

    public CheckoutPage1(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return ContinueButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return false;
        }
    }

    public IWebElement Title = Driver.FindElement(_titleBy);
    public IWebElement FirstName = Driver.FindElement(_firstName);
    public IWebElement LastName = Driver.FindElement(_lastName);
    public IWebElement PostalCode = Driver.FindElement(_postalCode);
    public IWebElement ContinueButton = IContinueButton.FindContinueButton(Driver);
}

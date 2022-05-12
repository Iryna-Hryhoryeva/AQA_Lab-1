using System;
using OpenQA.Selenium;
using PageObject.Entities;
using PageObject.Services;

namespace PageObject.Pages.CheckoutPages;

public class CheckoutPage1 : BasePage
{
    private const string _endPoint = "/checkout-step-one.html";
    public IWebElement Title = Driver.FindElement(By.ClassName("title"));
    public IWebElement FirstName = Driver.FindElement(By.Id("first-name"));
    public IWebElement LastName = Driver.FindElement(By.Id("last-name"));
    public IWebElement PostalCode = Driver.FindElement(By.Id("postal-code"));
    public IWebElement ContinueButton = Driver.FindElement(By.ClassName(Buttons.ContinueButtonClassName));

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
}

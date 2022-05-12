using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Entities;
using PageObject.Services;

namespace PageObject.Pages;

public class CartPage : BasePage
{
    private const string _endPoint = "/cart.html";
    public IWebElement Title = Driver.FindElement(By.ClassName("title"));
    public ReadOnlyCollection<IWebElement> ListOfItems = Driver.FindElements(By.CssSelector("div.inventory_item_name"));
    public IWebElement Quantity = Driver.FindElement(By.ClassName("cart_quantity"));
    public IWebElement CheckoutButton = Driver.FindElement(By.ClassName(Buttons.ContinueButtonClassName));

    public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return CheckoutButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return false;
        }
    }
}

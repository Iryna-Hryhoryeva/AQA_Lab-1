using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Buttons;
using PageObject.Services;

namespace PageObject.Pages;

public class CartPage : BasePage, IHaveBurgerButton, IHaveCartButton, IGoBackButton, IHaveSocialNetworks, IContinueButton
{
    private const string _endPoint = "/cart.html";
    private static readonly By _titleBy = By.ClassName("title");
    private static readonly By _quantityBy = By.ClassName("cart_quantity");
    private static readonly By _listOfItemsBy = By.CssSelector("div.inventory_item_name");

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

    public IWebElement Title = Driver.FindElement(_titleBy);
    public ReadOnlyCollection<IWebElement> ListOfItems = Driver.FindElements(_listOfItemsBy);
    public IWebElement Quantity = Driver.FindElement(_quantityBy);
    public IWebElement CheckoutButton = IContinueButton.FindContinueButton(Driver);
}

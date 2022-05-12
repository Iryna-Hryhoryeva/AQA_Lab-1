using System;
using OpenQA.Selenium;
using PageObject.Entities;
using PageObject.Services;
using PageObject.Tests;

namespace PageObject.Pages;

public class ItemPage : BasePage
{
    private string _endPoint = $"/inventory-item.html?id={ProductsTest.ProductId}";
    public Item Item;
    public IWebElement BackToProductsButton = Driver.FindElement(By.ClassName(Buttons.GoBackButtonClassName));

    public ItemPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
        Item = new Item(driver);
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + _endPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return BackToProductsButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return false;
        }
    }
}

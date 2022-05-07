using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Buttons;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage, IHaveBurgerButton, IHaveCartButton, IHaveSocialNetworks
{
    private const string _endPoint = "/inventory.html";
    private static readonly By _titleBy = By.ClassName("title");
    private static readonly By _productSortContainerBy = By.ClassName("product_sort_container");
    private static readonly By _eachProductPictureForListOfItemsBy = By.CssSelector("a[id*='_img_link']");

    public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return ProductSortContainer.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return false;
        }
    }

    public IWebElement ProductSortContainer => Driver.FindElement(_productSortContainerBy);
    public IWebElement Title => Driver.FindElement(_titleBy);
    public ReadOnlyCollection<IWebElement> ListOfItems => Driver.FindElements(_eachProductPictureForListOfItemsBy);
}

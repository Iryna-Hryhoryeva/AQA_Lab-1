using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage
{
    private const string _endPoint = "/inventory.html";
    public IWebElement ProductSortContainer => Driver.FindElement(By.ClassName("product_sort_container"));
    public IWebElement Title => Driver.FindElement(By.ClassName("title"));
    public ReadOnlyCollection<IWebElement> ListOfItems => Driver.FindElements(By.CssSelector("a[id*='_img_link']"));

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
}

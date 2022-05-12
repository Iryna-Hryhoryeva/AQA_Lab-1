using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Entities;

public class Item
{
    public static IWebDriver Driver { get; set; }
    public IWebElement Title => Driver.FindElement(By.XPath(
        "//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('name') +1) = 'name' or contains(@class, 'name ')]"));
    public IWebElement Description => Driver.FindElement(By.XPath(
        "//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('desc') +1) = 'desc' or contains(@class, 'desc ')]"));
    public IWebElement Price => Driver.FindElement(By.XPath(
        "//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('price') +1) = 'price' or contains(@class, 'price ')]"));
    public static IWebElement Picture => Driver.FindElement(By.XPath(
        "//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('img') +1) = 'img' or contains(@class, 'img ')]"));

    public static IWebElement AddOrRemoveButton => Driver.FindElement(By.CssSelector(".btn.btn_small.btn_inventory"));

    public Item(IWebDriver driver)
    {
        Driver = driver;
    }

    public IWebElement AddOrRemoveProduct(bool addProduct)
    {
        const string cartIndicatorXPathLocator = "//a[@class='shopping_cart_link']";
        var cartIndicator = Driver.FindElement(By.XPath(cartIndicatorXPathLocator));

        if (addProduct && AddOrRemoveButton.GetAttribute("class").Contains("btn_primary"))
        {
            Assert.That(cartIndicator.Text.Length.Equals(0));
            AddOrRemoveButton.Click();
            var cartIndicatorNumber = Driver.FindElement(By.XPath($"{cartIndicatorXPathLocator}/*"));
            Assert.That(cartIndicatorNumber.Text == "1");
        }
        else
        {
            var cartIndicatorNumber = Driver.FindElement(By.XPath($"{cartIndicatorXPathLocator}/*"));
            Assert.That(cartIndicatorNumber.Text == "1");
            AddOrRemoveButton.Click();
            Assert.That(cartIndicator.Text.Length.Equals(0));
        }

        return cartIndicator;
    }
}

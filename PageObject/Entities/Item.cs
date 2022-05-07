using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Entities;

public class Item 
{
    private static readonly By _titleBy = By.XPath("//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('name') +1) = 'name' or contains(@class, 'name ')]");
    private static readonly By _descriptionBy = By.XPath("//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('desc') +1) = 'desc' or contains(@class, 'desc ')]");
    private static readonly By _priceBy = By.XPath("//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('price') +1) = 'price' or contains(@class, 'price ')]");
    private static readonly By _pictureBy = By.XPath("//div[starts-with(@class,'inventory')][substring(@class, string-length(@class) - string-length('img') +1) = 'img' or contains(@class, 'img ')]");
    private static readonly By _addOrRemoveButtonBy = By.CssSelector(".btn.btn_small.btn_inventory");

    public Item(IWebDriver driver)
    {
       Driver = driver;
    }

    public static IWebDriver Driver { get; set; }
    public IWebElement Title => Driver.FindElement(_titleBy);
    public IWebElement Description => Driver.FindElement(_descriptionBy);
    public IWebElement Price => Driver.FindElement(_priceBy);
    public static IWebElement Picture => Driver.FindElement(_pictureBy);
    public static IWebElement AddOrRemoveButton => Driver.FindElement(_addOrRemoveButtonBy);

    public IWebElement AddOrRemoveProduct(bool addProduct)
    {
        const string cartIndicatorXPathLocator = "//a[@class='shopping_cart_link']";
        var cartIndicatorBy = By.XPath(cartIndicatorXPathLocator);
        var cartIndicator = Driver.FindElement(cartIndicatorBy);
        var cartIndicatorNumberBy = By.XPath($"{cartIndicatorXPathLocator}/*");
        
        if (addProduct && AddOrRemoveButton.GetAttribute("class").Contains("btn_primary"))
        {
            Assert.That(cartIndicator.Text.Length.Equals(0));
            AddOrRemoveButton.Click();
            var cartIndicatorNumber = Driver.FindElement(cartIndicatorNumberBy);
            Assert.That(cartIndicatorNumber.Text == "1");
        }
        else
        {
            var cartIndicatorNumber = Driver.FindElement(cartIndicatorNumberBy);
            Assert.That(cartIndicatorNumber.Text == "1");
            AddOrRemoveButton.Click();
            Assert.That(cartIndicator.Text.Length.Equals(0));
        }

        return cartIndicator;
    }
}

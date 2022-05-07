using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObject.Pages;
using PageObject.Utils;

namespace PageObject.Tests;

public class ProductsTest : BaseTest
{
    public static string ProductId { get; set; }

    [Test]
    public static void SortProductsByPriceFromLowToHigh()
    {
        LoginTest.Should_LogIn_If_ValidInputs();
        var productsPage = new ProductsPage(Driver, false);
        
        var productSortContainer = new SelectElement(productsPage.ProductSortContainer);
        productSortContainer.SelectByValue("lohi");
        
        var priceOfFirstProductBy = By.CssSelector(".inventory_list div.inventory_item:nth-child(1) div.inventory_item_price");
        var priceOfFirstProductElement = Driver.FindElement(priceOfFirstProductBy);
        var priceOfSecondProductBy = By.CssSelector(".inventory_list div.inventory_item:nth-child(2) div.inventory_item_price");
        var priceOfSecondProductElement = Driver.FindElement(priceOfSecondProductBy);
        
        var priceOfFirstProduct = RegexFormatter.RemoveOddCharsAndMakeDouble(priceOfFirstProductElement.Text);
        var priceOfSecondProduct = RegexFormatter.RemoveOddCharsAndMakeDouble(priceOfSecondProductElement.Text);

        Assert.That(priceOfFirstProduct < priceOfSecondProduct);
    }

    [Test]
    public static void ShowItemInfoAs1ItemOn1Page()
    {
        SortProductsByPriceFromLowToHigh();
        var productsPage = new ProductsPage(Driver, false);
        var cheapestProductElement = productsPage.ListOfItems[0];
        
        Assert.That(cheapestProductElement.GetAttribute("id") == "item_2_img_link");
        ProductId = RegexFormatter.GetOnlyNumbersAsStringFrom(cheapestProductElement.GetAttribute("id"));
        
        cheapestProductElement.Click();

        var itemPage = new ItemPage(Driver, false);
        Assert.AreEqual("sauce labs onesie", itemPage.Item.Title.Text.ToLower());
    }
}

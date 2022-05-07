using NUnit.Framework;
using PageObject.Pages;

namespace PageObject.Tests;

public class ItemPageTest : BaseTest
{
    [Test]
    public static void AddItemAndGoToCart()
    {
        ProductsTest.ShowItemInfoAs1ItemOn1Page();

        var itemPage = new ItemPage(Driver, false);
        Assert.That(itemPage.Item.Title.Text == "Sauce Labs Onesie");

        var shoppingCartLinkElement = itemPage.Item.AddOrRemoveProduct(true);
        shoppingCartLinkElement.Click();

        var cart = new CartPage(Driver, false);
        Assert.AreEqual("your cart", cart.Title.Text.ToLower());
    }
}

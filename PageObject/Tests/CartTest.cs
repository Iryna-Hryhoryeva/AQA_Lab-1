using NUnit.Framework;
using PageObject.Pages;
using PageObject.Pages.CheckoutPages;

namespace PageObject.Tests;

public class CartTest : BaseTest
{
    [Test]
    public static void Checkout()
    {
        ItemPageTest.AddItemAndGoToCart();
        var cart = new CartPage(Driver, false);
        Assert.AreEqual("your cart", cart.Title.Text.ToLower());
        Assert.AreEqual("sauce labs onesie", cart.ListOfItems[0].Text.ToLower());
        Assert.That(cart.Quantity.Text.Equals("1"));

        cart.CheckoutButton.Click();
        var checkoutPage1 = new CheckoutPage1(Driver, false);
        Assert.That(checkoutPage1.Title.Text.ToLower() == "checkout: your information");
    }
}

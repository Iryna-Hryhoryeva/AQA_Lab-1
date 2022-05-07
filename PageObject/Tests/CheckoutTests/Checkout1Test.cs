using NUnit.Framework;
using PageObject.Pages.CheckoutPages;
using PageObject.Services;

namespace PageObject.Tests.CheckoutTests;

public class Checkout1Test : BaseTest
{
    [Test]
    [Category("Positive")]
    public static void SendValidValues()
    {
        CartTest.Checkout();
        var checkoutPage1 = new CheckoutPage1(Driver, false);
        checkoutPage1.FirstName.SendKeys(Configurator.FirstName);
        checkoutPage1.LastName.SendKeys(Configurator.LastName);
        checkoutPage1.PostalCode.SendKeys(Configurator.PostalCode);

        checkoutPage1.ContinueButton.Click();

        var checkoutPage2 = new CheckoutPage2(Driver, false);
        Assert.That(checkoutPage2.Title.Text.ToUpper() == "CHECKOUT: OVERVIEW");
    }
}

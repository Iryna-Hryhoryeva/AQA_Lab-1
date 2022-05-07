using NUnit.Framework;
using PageObject.Pages.CheckoutPages;
using PageObject.Services;

namespace PageObject.Tests.CheckoutTests;

public class Checkout3Test : BaseTest
{
    [Test]
    public static void ShowFinalConfirmation()
    {
        Checkout2Test.ShowOverviewAndFinish();

        var checkoutPage3 = new CheckoutPage3(Driver, false);
        Assert.That(checkoutPage3.ThankYouMessage.Text == "THANK YOU FOR YOUR ORDER");
    }

    [Test]
    public static void GoBackToProductsList()
    {
        ShowFinalConfirmation();
        var checkoutPage3 = new CheckoutPage3(Driver, false);

        checkoutPage3.BackHomeButton.Click();
        Assert.That(Driver.Url == Configurator.BaseUrl + "/inventory.html");
    }
}

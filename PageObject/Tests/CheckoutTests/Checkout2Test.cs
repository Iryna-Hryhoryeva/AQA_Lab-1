using NUnit.Framework;
using PageObject.Pages.CheckoutPages;
using PageObject.Utils;

namespace PageObject.Tests.CheckoutTests;

public class Checkout2Test : BaseTest
{
    [Test]
    public static void ShowOverviewAndFinish()
    {
        Checkout1Test.SendValidValues();
        var checkoutPage2 = new CheckoutPage2(Driver, false);

        var itemTotalAsDouble = RegexFormatter.RemoveOddCharsAndMakeDouble(checkoutPage2.ItemTotal.Text.ToLower());
        var taxAsDouble = RegexFormatter.RemoveOddCharsAndMakeDouble(checkoutPage2.Tax.Text.ToLower());
        var totalAsDouble = RegexFormatter.RemoveOddCharsAndMakeDouble(checkoutPage2.Total.Text.ToLower());
        Assert.IsTrue(itemTotalAsDouble + taxAsDouble == totalAsDouble);

        checkoutPage2.FinishButton.Click();
        var checkoutPage3 = new CheckoutPage3(Driver, false);
        Assert.That(checkoutPage3.Title.Text.ToUpper() == "CHECKOUT: COMPLETE!");
    }
}

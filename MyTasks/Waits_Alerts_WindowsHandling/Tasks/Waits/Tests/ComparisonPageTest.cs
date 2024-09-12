using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Tasks.Waits.Pages;

namespace Waits_Alerts_WindowsHandling.Tasks.Waits.Tests;

public class ComparisonPageTest : BaseTest
{
    [Test]
    public void TestForComparisonPage()
    {
        OnlinerTVsPageTest.Should_GoToComparisonPage_After_First2TVsSelected_And_ComparisonButtonClicked();

        var comparisonPage = new ComparisonPage(Driver, false);

        var actionsProvider = new Actions(Driver);
        actionsProvider.MoveToElement(comparisonPage.ScreenSize).Perform();

        var questionIcon = WaitService.WaitElementExists(By.CssSelector("tr:hover .product-table-tip__trigger"));

        actionsProvider.Click(questionIcon).Perform();

        var popupTip = WaitService.WaitElementExists(By.CssSelector(".product-table-tip__tip_visible"));

        questionIcon.Click();

        var hasPopupTipDisappeared = WaitService.WaitForElementToDisappear(By.CssSelector(".product-table-tip__tip_visible"));
        Assert.IsTrue(hasPopupTipDisappeared);

        var deleteItemCross = WaitService.WaitElementIsVisible(            By.XPath(
                "//th[@class='product-table__cell']/div[@class='product-table-cell-container']/a[@data-key='oled55c1rla']"));

        var itemToBeDeleted = WaitService.WaitElementIsVisible(By.XPath("//span[@class='product-summary__caption'][text() = 'OLED телевизор LG OLED55C1RLA']"));

        deleteItemCross.Click();

        var hasItemToBeDeletedDisappeared = WaitService.WaitForElementToDisappear(By.XPath("//span[@class='product-summary__caption'][text() = 'OLED телевизор LG OLED55C1RLA']"));
        Assert.IsTrue(hasItemToBeDeletedDisappeared);

        WaitService.WaitPageRefreshed("https://catalog.onliner.by/compare/oled65c1rla");
    }
}

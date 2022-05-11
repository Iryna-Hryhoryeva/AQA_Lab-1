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

        var questionIconBy = By.CssSelector("tr:hover .product-table-tip__trigger");
        var questionIcon = WaitService.WaitElementExists(questionIconBy);

        actionsProvider.Click(questionIcon).Perform();

        var popupTipBy = By.CssSelector(".product-table-tip__tip_visible");
        var popupTip = WaitService.WaitElementExists(popupTipBy);

        questionIcon.Click();

        var hasPopupTipDisappeared = WaitService.WaitForElementToDisappear(popupTipBy);
        Assert.IsTrue(hasPopupTipDisappeared);

        var deleteItemCrossBy =
            By.XPath(
                "//th[@class='product-table__cell']/div[@class='product-table-cell-container']/a[@data-key='oled55c1rla']");
        var deleteItemCross = WaitService.WaitElementIsVisible(deleteItemCrossBy);

        var itemToBeDeletedBy =
            By.XPath("//span[@class='product-summary__caption'][text() = 'OLED телевизор LG OLED55C1RLA']");
        var itemToBeDeleted = WaitService.WaitElementIsVisible(itemToBeDeletedBy);

        deleteItemCross.Click();

        var hasItemToBeDeletedDisappeared = WaitService.WaitForElementToDisappear(itemToBeDeletedBy);
        Assert.IsTrue(hasItemToBeDeletedDisappeared);

        WaitService.WaitPageRefreshed("https://catalog.onliner.by/compare/oled65c1rla");
    }
}

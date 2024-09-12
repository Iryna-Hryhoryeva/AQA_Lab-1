using NUnit.Framework;
using Should;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Tasks.Waits.Pages;

namespace Waits_Alerts_WindowsHandling.Tasks.Waits.Tests;

public class OnlinerTVsPageTest : BaseTest
{
    [Test]
    public static void Should_GoToComparisonPage_After_First2TVsSelected_And_ComparisonButtonClicked()
    {
        var onlinerTVspage = new OnlinerTVsPage(Driver, true);

        onlinerTVspage.FirstCheckBoxSelectingTV.Click();
        onlinerTVspage.SecondCheckBoxSelectingTV.Click();

        onlinerTVspage.ComparisonButton.Click();

        var comparisonPage = new ComparisonPage(Driver, false);
        comparisonPage.Title.Text.ShouldEqual("Сравнение товаров");
    }
}

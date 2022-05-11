using System;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.Tasks.Waits.Pages;

public class ComparisonPage : BasePage
{
    private const string _endPoint = "/compare/oled55c1rla+oled65c1rla";
    private static readonly By _screenSizeBy = By.XPath("//span[@class ='product-table__wrapper'][text() = 'Диагональ экрана']");
    private static readonly By _titleBy = By.ClassName("b-offers-title");

    public ComparisonPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.OnlinerBaseUrl + _endPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return NumberOfOffersButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }

    public IWebElement ScreenSize = WaitService.WaitElementIsVisible(_screenSizeBy);
    public IWebElement Title = WaitService.WaitElementIsVisible(_titleBy);
}

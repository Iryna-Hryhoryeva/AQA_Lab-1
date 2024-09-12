using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.Tasks;

public class OnlinerTVsPage : BasePage
{
    private const string _endPoint = "/tv";
    public static ReadOnlyCollection<IWebElement> CheckBoxes => WaitService.WaitElementsPresent(By.CssSelector("[class = 'schema-product__control']"));
    public IWebElement FirstCheckBoxSelectingTV => CheckBoxes[0];
    public IWebElement SecondCheckBoxSelectingTV => CheckBoxes[1];
    public IWebElement ComparisonButton => WaitService.WaitElementIsVisible(By.CssSelector("[data-bind = 'html: $root.text']"));
    public IWebElement Title => WaitService.WaitElementExists(By.CssSelector("[class = 'schema-header__title js-schema-header_title']"));

    public struct SocialNetworks
    {
        public IWebElement VK = WaitService.WaitElementExists(By.ClassName("footer-style__social-button_vk"));
        public IWebElement Facebook = WaitService.WaitElementExists(By.ClassName("footer-style__social-button_fb"));
        public IWebElement Twitter = WaitService.WaitElementExists(By.ClassName("footer-style__social-button_tw"));

        public SocialNetworks()
        {
        }
    }
    
    public OnlinerTVsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
}

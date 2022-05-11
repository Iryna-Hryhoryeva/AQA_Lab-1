using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.Tasks;

public class OnlinerTVsPage : BasePage
{
    private const string _endPoint = "/tv";
    private static readonly By _titleBy = By.CssSelector("[class = 'schema-header__title js-schema-header_title']");
    private static readonly By _checkBoxesBy = By.CssSelector("[class = 'schema-product__control']");
    private static readonly By _comparisonButtonBy = By.CssSelector("[data-bind = 'html: $root.text']");
    private static readonly By _vkBy = By.ClassName("footer-style__social-button_vk");
    private static readonly By _facebookBy = By.ClassName("footer-style__social-button_fb");
    private static readonly By _twitterBy = By.ClassName("footer-style__social-button_tw");

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

    public static ReadOnlyCollection<IWebElement> CheckBoxes => WaitService.WaitElementsPresent(_checkBoxesBy);
    public IWebElement FirstCheckBoxSelectingTV => CheckBoxes[0];
    public IWebElement SecondCheckBoxSelectingTV => CheckBoxes[1];
    public IWebElement ComparisonButton => WaitService.WaitElementIsVisible(_comparisonButtonBy);
    public IWebElement Title => WaitService.WaitElementExists(_titleBy);

    public struct SocialNetworks
    {
        public IWebElement VK = WaitService.WaitElementExists(_vkBy);
        public IWebElement Facebook = WaitService.WaitElementExists(_facebookBy);
        public IWebElement Twitter = WaitService.WaitElementExists(_twitterBy);

        public SocialNetworks()
        {
        }
    }
}

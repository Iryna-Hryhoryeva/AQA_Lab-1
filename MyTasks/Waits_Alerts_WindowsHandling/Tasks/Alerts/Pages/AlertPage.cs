using System;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.Tasks.Alerts.Pages;

public class AlertPage : BasePage
{
    private const string _endPoint = "/javascript_alerts";
    private static readonly By _buttonForSimpleAlertBy = By.CssSelector("[onclick='jsAlert()']");
    private static readonly By _buttonForConfirmationAlertBy = By.CssSelector("[onclick='jsConfirm()']");
    private static readonly By _buttonForPromptAlertBy = By.CssSelector("[onclick='jsPrompt()']");
    private static readonly By _resultBy = By.Id("result");

    public AlertPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.HerokuappBaseUrl + _endPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return ButtonForSimpleAlert.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IWebElement ButtonForSimpleAlert => WaitService.WaitQuickElement(_buttonForSimpleAlertBy);
    public IWebElement ButtonForConfirmationAlert => WaitService.WaitElementExists(_buttonForConfirmationAlertBy);
    public IWebElement ButtonForPromptAlert => WaitService.WaitElementExists(_buttonForPromptAlertBy);
    public IWebElement Result => WaitService.WaitElementExists(_resultBy);
}

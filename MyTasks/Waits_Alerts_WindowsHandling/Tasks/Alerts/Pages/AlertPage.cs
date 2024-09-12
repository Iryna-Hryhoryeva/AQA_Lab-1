using System;
using OpenQA.Selenium;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Services;

namespace Waits_Alerts_WindowsHandling.Tasks.Alerts.Pages;

public class AlertPage : BasePage
{
    private const string _endPoint = "/javascript_alerts";
    public IWebElement ButtonForSimpleAlert => WaitService.WaitQuickElement(By.CssSelector("[onclick='jsAlert()']"));

    public IWebElement ButtonForConfirmationAlert =>
        WaitService.WaitElementExists(By.CssSelector("[onclick='jsConfirm()']"));

    public IWebElement ButtonForPromptAlert => WaitService.WaitElementExists(By.CssSelector("[onclick='jsPrompt()']"));
    public IWebElement Result => WaitService.WaitElementExists(By.Id("result"));

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
}

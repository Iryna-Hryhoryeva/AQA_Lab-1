using NUnit.Framework;
using Waits_Alerts_WindowsHandling.BaseEntities;
using Waits_Alerts_WindowsHandling.Tasks.Alerts.Pages;
using Waits_Alerts_WindowsHandling.Utils;

namespace Waits_Alerts_WindowsHandling.Tasks.Alerts.Tests;

public class AlertPageTest : BaseTest
{
    [Test]
    public void Test_JS_Alert()
    {
        var alertPage = new AlertPage(Driver, true);
        alertPage.ButtonForSimpleAlert.Click();

        var simpleAlert = Driver.SwitchTo().Alert();
        var alertText = simpleAlert.Text;
        Log.Info(alertText);

        simpleAlert.Accept();

        Assert.AreEqual("You successfully clicked an alert", alertPage.Result.Text);
    }

    [Test]
    public void Test_Confirmation_Alert()
    {
        var alertPage = new AlertPage(Driver, true);
        alertPage.ButtonForConfirmationAlert.Click();

        var confirmationAlert = Driver.SwitchTo().Alert();
        var alertText = confirmationAlert.Text;
        Log.Info(alertText);
        confirmationAlert.Accept();

        Assert.AreEqual("You clicked: Ok", alertPage.Result.Text);
    }

    [Test]
    public void Test_Prompt_Alert_OK()
    {
        var alertPage = new AlertPage(Driver, true);
        alertPage.ButtonForPromptAlert.Click();

        var promptAlert = Driver.SwitchTo().Alert();
        var alertText = promptAlert.Text;
        Log.Info(alertText);

        promptAlert.SendKeys("Great site");
        promptAlert.Accept();
        Log.Info(alertPage.Result.Text);

        Assert.AreEqual("You entered: Great site", alertPage.Result.Text);
    }

    [Test]
    public void Test_Prompt_Alert_Cancel()
    {
        var alertPage = new AlertPage(Driver, true);

        alertPage.ButtonForPromptAlert.Click();

        var promptAlert = Driver.SwitchTo().Alert();
        promptAlert.Dismiss();

        Assert.AreEqual("You entered: null", alertPage.Result.Text);
    }
}

using System.Collections;
using NUnit.Framework;
using PageObject.Buttons;
using PageObject.Pages;
using PageObject.Services;
using PageObject.Utils;

namespace PageObject.Tests;

public class LoginTest : BaseTest
{
    [Category("Positive")]
    [Test]
    public static void Should_LogIn_If_ValidInputs()
    {
        var loginPage = new LoginPage(Driver, true);

        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Click();

        var productsPage = new ProductsPage(Driver, false);

        Assert.AreEqual("products", productsPage.Title.Text.ToLower());
    }

    [Category("Negative")]
    [Test]
    public static void Should_FailToLogIn_WithAtLeast1EmptyField()
    {
        var loginPage = new LoginPage(Driver, true);

        var isUsernameFieldEmpty = loginPage.UsernameInput.GetAttribute("value").Length == 0;
        var isPasswordFieldEmpty = loginPage.PasswordInput.GetAttribute("value").Length == 0;
        Assert.That(isUsernameFieldEmpty || isPasswordFieldEmpty);

        loginPage.LoginButton.Click();

        IErrorMessage.FindErrorMessageForEmptyLogin(Driver,
            isUsernameFieldEmpty ? loginPage.UsernameInput : loginPage.PasswordInput);
    }

    [Category("Negative")]
    [TestCaseSource(typeof(InvalidDataForLoginTest), nameof(InvalidDataForLoginTest.TestCases))]
    public static void Should_FailToLogIn_ForInvalidUsernameOrPassword(string username, string password)
    {
        var loginPage = new LoginPage(Driver, true);
        
        loginPage.UsernameInput.SendKeys(username);
        loginPage.PasswordInput.SendKeys(password);

        loginPage.LoginButton.Click();

        IErrorMessage.FindErrorMessageForInvalidLoginInputs(Driver);
    }
    
    private static class InvalidDataForLoginTest
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(
                    Configurator.ValidUsernames[Randomizer.GetRandomIndex(Configurator.ValidUsernames)].Value +
                    " *(o_0)*/", Configurator.Password);

                foreach (var username in Configurator.ValidUsernames)
                {
                    yield return new TestCaseData(username.Value, Configurator.Password + "pan");
                }
            }
        }
    }
}

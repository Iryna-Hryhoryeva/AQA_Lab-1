using System;
using OpenQA.Selenium;
using PageObject.Entities;
using PageObject.Services;

namespace PageObject.Pages;

public class LoginPage : BasePage
{
    private const string _endPoint = "/";
    public IWebElement UsernameInput => Driver.FindElement(By.Id("user-name"));
    public IWebElement PasswordInput => Driver.FindElement(By.Id("password"));
    public IWebElement LoginButton => Driver.FindElement(By.ClassName(Buttons.ContinueButtonClassName));

    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + _endPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return LoginButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }
}

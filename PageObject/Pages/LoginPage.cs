using System;
using OpenQA.Selenium;
using PageObject.Buttons;
using PageObject.Services;

namespace PageObject.Pages;

public class LoginPage : BasePage, IContinueButton
{
    private const string _endPoint = "/";
    private static readonly By UsernameInputBy = By.Id("user-name");
    private static readonly By PasswordInputBy = By.Id("password");
    private static readonly By _errorMessageBy;

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

    public IWebElement UsernameInput => Driver.FindElement(UsernameInputBy);
    public IWebElement PasswordInput => Driver.FindElement(PasswordInputBy);
    public IWebElement LoginButton => IContinueButton.FindContinueButton(Driver);
}

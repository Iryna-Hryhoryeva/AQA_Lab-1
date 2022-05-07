using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Buttons;

public interface IErrorMessage
{
    private static readonly By _errorMessageBy = By.CssSelector("h3[data-test='error']");

    public static void FindErrorMessageForEmptyLogin(IWebDriver driver, IWebElement element)
    {
        AssertErrorMessageText(element.GetAttribute("id") == "user-name" ? "Username" : "Password", driver);
    }

    private static void AssertErrorMessageText(string fieldName, IWebDriver driver)
    {
        var errorMessage = driver.FindElement(_errorMessageBy);
        var errorText = $"Epic sadface: {fieldName} is required";
        Assert.That(errorMessage.Text == errorText);
    }

    public static void FindErrorMessageForInvalidLoginInputs(IWebDriver driver)
    {
        var errorMessage = driver.FindElement(_errorMessageBy);
        Assert.That(errorMessage.Text == "Epic sadface: Username and password do not match any user in this service");
    }

    public static void FindErrorMessageWith(string pageEndPoint, IWebDriver driver)
    {
        var errorMessage = driver.FindElement(_errorMessageBy);
        Assert.That(errorMessage.Text == $"Epic sadface: You can only access '{pageEndPoint}' when you are logged in.");
    }
}

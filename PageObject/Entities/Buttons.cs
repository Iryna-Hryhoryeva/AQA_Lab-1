using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Entities;

public static class Buttons
{
    public static string ContinueButtonClassName = "btn_action";
    public static string GoBackButtonClassName = "back";
    public static string BurgerButtonId = "react-burger-menu-btn";
    public static string SocialNetworksButtonClassName = "social";
    public static string CartButtonClassName = "shopping_cart_link";
    public static string ErrorMessageCss = "h3[data-test='error']";

    public static void FindErrorMessageForEmptyLogin(IWebElement element, IWebDriver driver)
    {
        AssertErrorMessageText(element.GetAttribute("id") == "user-name" ? "Username" : "Password", driver);
    }

    private static void AssertErrorMessageText(string fieldName, IWebDriver driver)
    {
        var errorText = $"Epic sadface: {fieldName} is required";
        Assert.That(driver.FindElement(By.CssSelector(ErrorMessageCss)).Text == errorText);
    }

    public static void FindErrorMessageForInvalidLoginInputs(IWebDriver driver)
    {
        Assert.That(driver.FindElement(By.CssSelector(ErrorMessageCss)).Text ==
                    "Epic sadface: Username and password do not match any user in this service");
    }

    public static void FindErrorMessageWith(string pageEndPoint, IWebDriver driver)
    {
        Assert.That(driver.FindElement(By.CssSelector(ErrorMessageCss)).Text ==
                    $"Epic sadface: You can only access '{pageEndPoint}' when you are logged in.");
    }
}

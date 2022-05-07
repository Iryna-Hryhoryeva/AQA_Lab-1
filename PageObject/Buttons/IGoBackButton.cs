using OpenQA.Selenium;

namespace PageObject.Buttons;

public interface IGoBackButton
{
    public static IWebElement FindGoBackButton(IWebDriver driver)
    {
        var goBackButtonBy = By.ClassName("back");

        return driver.FindElement(goBackButtonBy);
    }
}

using OpenQA.Selenium;

namespace PageObject.Buttons;

public interface IContinueButton
{
    public static IWebElement FindContinueButton(IWebDriver driver)
    {
        var continueButtonBy = By.ClassName("btn_action");

        return driver.FindElement(continueButtonBy);
    }
}

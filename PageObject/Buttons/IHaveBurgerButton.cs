using OpenQA.Selenium;

namespace PageObject.Buttons;

public interface IHaveBurgerButton
{
    public static IWebElement FindBurgerButton(IWebDriver driver)
    {
        var burgerButtonBy = By.Id("react-burger-menu-btn");

        return driver.FindElement(burgerButtonBy);
    }
}

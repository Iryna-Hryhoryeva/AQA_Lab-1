using OpenQA.Selenium;

namespace PageObject.Buttons;

public interface IHaveCartButton
{
    public static IWebElement FindCartButton(IWebDriver driver)
    {
        var cartButtonBy = By.ClassName("shopping_cart_link");

        return driver.FindElement(cartButtonBy);
    }
}

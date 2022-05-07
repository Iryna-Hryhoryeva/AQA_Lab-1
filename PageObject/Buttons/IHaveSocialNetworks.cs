using OpenQA.Selenium;

namespace PageObject.Buttons;

public interface IHaveSocialNetworks
{
    public static IWebElement FindSocialNetworks(IWebDriver driver)
    {
        var socialNetworksBy = By.ClassName("social");

        return driver.FindElement(socialNetworksBy);
    }
}

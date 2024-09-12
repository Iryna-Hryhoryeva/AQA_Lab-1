using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Waits_Alerts_WindowsHandling.BaseEntities;

namespace Waits_Alerts_WindowsHandling.Tasks.Windows.Tests;

public class WindowsTest : BaseTest
{
    [Test]
    public void Test_Windows_On_Onliner_VK()
    {
        var onlinerPage = new OnlinerTVsPage(Driver, true);
        var parentWindow = Driver.CurrentWindowHandle;
        var socialNetworks = new OnlinerTVsPage.SocialNetworks();
        var actionsProvider = new Actions(Driver);

        socialNetworks.VK.Click();
        var windows = Driver.WindowHandles;
        Assert.AreEqual(2, windows.Count, "There's a different number of windows.");

        Driver.SwitchTo().Window(windows[1]);
        var mainPageButton = WaitService.WaitElementExists(By.ClassName("TopHomeLink"));
        actionsProvider.KeyDown(Keys.LeftControl);
        actionsProvider.Click(mainPageButton).Perform();
        actionsProvider.KeyUp(Keys.LeftControl);

        windows = Driver.WindowHandles;

        Driver.SwitchTo().Window(windows[2]);
        var loginMobileHeader = WaitService.WaitElementExists(By.ClassName("login_mobile_header"));
        Assert.AreEqual("ВКонтакте для мобильных устройств", loginMobileHeader.Text);
        Driver.Close();

        Driver.SwitchTo().Window(windows[1]);
        Driver.Close();

        Driver.SwitchTo().Window(parentWindow);
        Assert.AreEqual("Телевизоры", onlinerPage.Title.Text);
    }

    [Test]
    public void Test_Windows_On_Onliner_Facebook()
    {
        var onlinerPage = new OnlinerTVsPage(Driver, true);
        var parentWindow = Driver.CurrentWindowHandle;
        var socialNetworks = new OnlinerTVsPage.SocialNetworks();

        socialNetworks.Facebook.Click();
        var windows = Driver.WindowHandles;
        Assert.AreEqual(2, windows.Count, "There's a different number of windows.");

        Driver.SwitchTo().Window(windows[1]);
        var informationButton =
            WaitService.WaitElementExists(
                By.XPath("//a[@href = 'https://www.facebook.com/onlinerby/about/?ref=page_internal']"));
        informationButton.Click();

        var informationSection = WaitService.WaitElementExists(By.CssSelector("div.hcukyx3x.c1et5uql div"));
        Assert.AreEqual("Новости Беларуси: деньги, лайфстайл, недвижимость, технологии, авто.",
            informationSection.Text);
        Driver.Close();

        Driver.SwitchTo().Window(parentWindow);
        Assert.AreEqual("Телевизоры", onlinerPage.Title.Text);
    }

    [Test]
    public void Test_Windows_On_Onliner_Twitter()
    {
        var onlinerPage = new OnlinerTVsPage(Driver, true);
        var parentWindow = Driver.CurrentWindowHandle;
        var socialNetworks = new OnlinerTVsPage.SocialNetworks();
        var actionsProvider = new Actions(Driver);

        socialNetworks.Twitter.Click();
        var windows = Driver.WindowHandles;
        Assert.AreEqual(2, windows.Count, "There's a different number of windows.");

        Driver.SwitchTo().Window(windows[1]);
        var nickNames = WaitService.WaitElementsPresent(By.CssSelector(
            "div[class*='css-901oao css-bfa6kz'] span[class*='css-901oao css-16my406']"));
       
        var onlinerNickName = nickNames[1];
        Assert.AreEqual("@OnlinerBY", onlinerNickName.Text);

        var hashtagButton = WaitService.WaitElementExists(By.CssSelector(
            "[class = 'css-1dbjc4n r-1awozwy r-sdzlij r-18u37iz r-1777fci r-dnmrzs r-xyw6el r-o7ynqc r-6416eg']"));
        actionsProvider.MoveToElement(hashtagButton);
        actionsProvider.KeyDown(Keys.LeftControl);
        actionsProvider.Click(hashtagButton).Perform();
        actionsProvider.KeyUp(Keys.LeftControl);

        windows = Driver.WindowHandles;

        Driver.SwitchTo().Window(windows[2]);
        var collection = WaitService.WaitElementsPresent(By.CssSelector(
            "div[class='css-901oao css-cens5h r-1kihuf0 r-18jsvk2 r-37j5jr r-adyw6z r-1vr29t4 r-135wba7 r-bcqeeo r-qvutc0'] > span"));
        do
        {
            foreach (var element in collection)
            {
                var found = element.Text == "Актуальные темы для вас";

                if (found)
                {
                    Assert.AreEqual("Актуальные темы для вас", element.Text);
                }
            }
        } while (false);

        Driver.Close();

        Driver.SwitchTo().Window(windows[1]);
        Driver.Close();

        Driver.SwitchTo().Window(parentWindow);
        Assert.AreEqual("Телевизоры", onlinerPage.Title.Text);
    }
}

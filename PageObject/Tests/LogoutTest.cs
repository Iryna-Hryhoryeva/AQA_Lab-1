using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Entities;
using PageObject.Services;

namespace PageObject.Tests;

public class LogoutTest : BaseTest
{
    [Ignore("Maybe another type of wait is needed to pass the test. " +
            "Also the method needs to be modified and then implemented within all the tests except login ones.")]
    [Test]
    public void Should_LogOut_If_WaitTimeGreaterThan5Minutes()
    {
        LoginTest.Should_LogIn_If_ValidInputs();

        var productElement = Driver.FindElement(By.CssSelector(".inventory_list div.inventory_item:nth-child(1) div.inventory_item_img a"));
        productElement.Click();

        Thread.Sleep(Configurator.WaitTimeoutInMinutes * 60 * 1000 + 1);
        Driver.Navigate().Refresh();

        Assert.That(Driver.Url == Configurator.BaseUrl);
        
        Buttons.FindErrorMessageWith("/inventory-item.html?id=4", Driver);
    }
}

using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators;

[TestFixture]
public class TestsOfWebpageForLocatorsHometask
{
    private WebDriver _driver;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _driver = new ChromeDriver();
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var fullPathToFile =
            $"{basePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}webpage_for_locators_hometask.html";
        _driver.Navigate().GoToUrl(fullPathToFile);
    }

    [Test]
    public void XPath_Test()
    {
        var elementsHavingTextTest = _driver.FindElements(By.XPath("//*[contains(text(), 'Test')]"));
        Assert.IsNotNull(elementsHavingTextTest);
        Console.WriteLine("secondElementHavingTextTest: " + elementsHavingTextTest[1]);

        var elementWithTextEqualsTestAndAttributeEqualsIds = _driver.FindElement(By.XPath("//*[@ids][text()='Test']"));
        Assert.IsNotNull(elementWithTextEqualsTestAndAttributeEqualsIds);
        Console.WriteLine("elementWithTextEqualsTestAndAttributeEqualsIds: " +
                          elementWithTextEqualsTestAndAttributeEqualsIds);

        var elementWithTextTitle2 = _driver.FindElement(By.XPath("//*[contains(text(), 'Title 2')]"));
        Assert.IsNotNull(elementWithTextTitle2);

        var elementH1WithTextTitle3 = _driver.FindElement(By.XPath("//h1/*[contains(text(), 'Title 3')]"));
        Assert.IsNotNull(elementH1WithTextTitle3);

        var secondArrowElementFromBlockWithTextTitle2 = _driver.FindElement(
            By.XPath("//*[contains(text(), 'Title 2')]/ancestor::div/descendant-or-self::*[@class='arrow'][2]"));
        Assert.IsNotNull(secondArrowElementFromBlockWithTextTitle2);
    }

    [Test]
    public void CSS_Test()
    {
        var elementWithTextLocator = _driver.FindElement(By.CssSelector("*[id='123']"));
        Assert.That(elementWithTextLocator.Text == "Locator");
        Console.WriteLine($"elementWithTextLocator: {elementWithTextLocator}");

        var elementsWithArrowClass = _driver.FindElements(By.CssSelector(".arrow"));
        Assert.GreaterOrEqual(elementsWithArrowClass.Count, 1);

        var elementWithIdEquals123 = _driver.FindElement(By.CssSelector("[id='123']"));
        Assert.NotNull(elementWithIdEquals123);
        Console.WriteLine("elementWithIdEquals123: " + elementWithIdEquals123);

        var spansWithParentH1 = _driver.FindElements(By.CssSelector("h1 span"));
        Assert.GreaterOrEqual(spansWithParentH1.Count, 1);

        var spansStartingWith12 = _driver.FindElements(By.CssSelector("span[value^='12']"));
        Assert.GreaterOrEqual(spansStartingWith12.Count, 1);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
}

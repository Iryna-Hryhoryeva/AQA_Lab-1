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
    public void Should_PrintSecondElementHavingTextTest()
    {
        var elementsHavingTextTestBy = By.XPath("//*[contains(text(), 'Test')]");
        var elementsHavingTextTest = _driver.FindElements(elementsHavingTextTestBy);
        Assert.IsNotNull(elementsHavingTextTest);
        Console.WriteLine("secondElementHavingTextTest: " + elementsHavingTextTest[1]);
    }

    [Test]
    public void Should_PrintElementWithTextEqualsTestAndAttributeEqualsIds()
    {
        var elementWithTextEqualsTestAndAttributeEqualsIdsBy = By.XPath("//*[@ids][text()='Test']");
        var elementWithTextEqualsTestAndAttributeEqualsIds =
            _driver.FindElement(elementWithTextEqualsTestAndAttributeEqualsIdsBy);
        Assert.IsNotNull(elementWithTextEqualsTestAndAttributeEqualsIds);
        Console.WriteLine("elementWithTextEqualsTestAndAttributeEqualsIds: " +
                          elementWithTextEqualsTestAndAttributeEqualsIds);
    }

    [Test]
    public void Should_FindElementWithTextTitle2_And_AssertItIsNotNull()
    {
        var elementWithTextTitle2By = By.XPath("//*[contains(text(), 'Title 2')]");
        var elementWithTextTitle2 = _driver.FindElement(elementWithTextTitle2By);
        Assert.IsNotNull(elementWithTextTitle2);
    }

    [Test]
    public void Should_FindElementH1WithTextTitle3_And_AssertItIsNotNull()
    {
        var elementH1WithTextTitle3By = By.XPath("//h1/*[contains(text(), 'Title 3')]");
        var elementH1WithTextTitle3 = _driver.FindElement(elementH1WithTextTitle3By);
        Assert.IsNotNull(elementH1WithTextTitle3);
    }

    [Test]
    public void Should_FindSecondArrowElementFromBlockWithTextTitle2_And_AssertItIsNotNull()
    {
        var secondArrowElementFromBlockWithTextTitle2By =
            By.XPath("//*[contains(text(), 'Title 2')]/ancestor::div/descendant-or-self::*[@class='arrow'][2]");
        var secondArrowElementFromBlockWithTextTitle2 =
            _driver.FindElement(secondArrowElementFromBlockWithTextTitle2By);
        Assert.IsNotNull(secondArrowElementFromBlockWithTextTitle2);
    }

    [Test]
    public void Should_PrintElementWithTextLocator()
    {
        var elementWithTextLocatorBy = By.CssSelector("*[id='123']");
        var elementWithTextLocator = _driver.FindElement(elementWithTextLocatorBy);
        Assert.That(elementWithTextLocator.Text == "Locator");
        Console.WriteLine($"elementWithTextLocator: {elementWithTextLocator}");
    }

    [Test]
    public void Should_PrintElementsWithArrowClass_If_ThereAtLeast1Element()
    {
        var elementsWithArrowClassBy = By.CssSelector(".arrow");
        var elementsWithArrowClass = _driver.FindElements(elementsWithArrowClassBy);
        Assert.GreaterOrEqual(elementsWithArrowClass.Count, 1);
        Services.PrintElements(elementsWithArrowClass, ".arrow");
    }

    [Test]
    public void Should_PrintElementWithIdEquals123()
    {
        var elementWithIdEquals123By = By.CssSelector("[id='123']");
        var elementWithIdEquals123 = _driver.FindElement(elementWithIdEquals123By);
        Assert.NotNull(elementWithIdEquals123);
        Console.WriteLine("elementWithIdEquals123: " + elementWithIdEquals123);
    }

    [Test]
    public void Should_PrintSpansWithParentH1_If_ThereAtLeast1Element()
    {
        var spansWithParentH1By = By.CssSelector("h1 span");
        var spansWithParentH1 = _driver.FindElements(spansWithParentH1By);
        Assert.GreaterOrEqual(spansWithParentH1.Count, 1);
        Services.PrintElements(spansWithParentH1, "h1 span");
    }

    [Test]
    public void Should_PrintSpansStartingWith12_If_ThereAtLeast1Element()
    {
        var spansStartingWith12By = By.CssSelector("span[value^='12']");
        var spansStartingWith12 = _driver.FindElements(spansStartingWith12By);
        Assert.GreaterOrEqual(spansStartingWith12.Count, 1);
        Services.PrintElements(spansStartingWith12, "span[value^='12']");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
}

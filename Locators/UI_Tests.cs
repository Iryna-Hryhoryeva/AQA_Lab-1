using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        wait.Until(driver => driver.FindElement(By.TagName("h1")).Displayed);
    }

    [Test]
    public void Should_PrintSecondElementHavingTextTest_If_ItIsDisplayed()
    {
        var elementsHavingTextTest = _driver.FindElements(By.XPath("//*[contains(text(), 'Test')]"));
        Assert.That(elementsHavingTextTest[1].Displayed);
        Console.WriteLine("secondElementHavingTextTest: " + elementsHavingTextTest[1]);
    }
    
    [Test]
    public void Should_PrintElementWithTextEqualsTestAndAttributeEqualsIds_If_ItIsDisplayed()
    {
        var elementWithTextEqualsTestAndAttributeEqualsIds = _driver.FindElement(By.XPath("//*[@ids][text()='Test']"));
        Assert.That(elementWithTextEqualsTestAndAttributeEqualsIds.Displayed);
        Console.WriteLine("elementWithTextEqualsTestAndAttributeEqualsIds: " +
                          elementWithTextEqualsTestAndAttributeEqualsIds);
    }
    
    [Test]
    public void Should_FindElementWithTextTitle2_And_AssertItIsDisplayed()
    {
        var elementWithTextTitle2 = _driver.FindElement(By.XPath("//*[contains(text(), 'Title 2')]"));
        Assert.That(elementWithTextTitle2.Displayed);
    }
    
    [Test]
    public void Should_FindElementH1WithTextTitle3_And_AssertIsDisplayed()
    {
        var elementH1WithTextTitle3 = _driver.FindElement(By.XPath("//h1/*[contains(text(), 'Title 3')]"));
        Assert.That(elementH1WithTextTitle3.Displayed);
    }
    
    [Test]
    public void Should_FindSecondArrowElementFromBlockWithTextTitle2_And_AssertDisplayed()
    {
        var secondArrowElementFromBlockWithTextTitle2 = _driver.FindElement
            (By.XPath("//*[contains(text(), 'Title 2')]/ancestor::div/descendant-or-self::*[@class='arrow'][2]"));
        Assert.That(secondArrowElementFromBlockWithTextTitle2.Displayed);
    }

    [Test]
    public void Should_FindElementWithTextLocator_And_AssertItsTextEqualsLocator()
    {
        var elementWithTextLocator = _driver.FindElement(By.CssSelector("*[id='123']"));
        Assert.That(elementWithTextLocator.Text == "Locator");
    }

    [Test]
    public void Should_PrintElementsWithArrowClass_If_ThereAtLeast1Element()
    {
        var elementsWithArrowClass = _driver.FindElements(By.CssSelector(".arrow"));
        Assert.GreaterOrEqual(elementsWithArrowClass.Count, 1);
        Services.PrintElements(elementsWithArrowClass, ".arrow");
    }

    [Test]
    public void Should_PrintElementWithIdEquals123_If_ElementWithIdEquals123IsDisplayed()
    {
        var elementWithIdEquals123 = _driver.FindElement(By.CssSelector("[id='123']"));
        Assert.That(elementWithIdEquals123.Displayed);
        Console.WriteLine("elementWithIdEquals123: " + elementWithIdEquals123);
    }

    [Test]
    public void Should_PrintSpansWithParentH1_If_ThereAtLeast1Element()
    {
        var spansWithParentH1 = _driver.FindElements(By.CssSelector("h1 span"));
        Assert.GreaterOrEqual(spansWithParentH1.Count, 1);
        Services.PrintElements(spansWithParentH1, "h1 span");
    }

    [Test]
    public void Should_PrintSpansStartingWith12_If_ThereAtLeast1Element()
    {
        var spansStartingWith12 = _driver.FindElements(By.CssSelector("span[value^='12']"));
        Assert.GreaterOrEqual(spansStartingWith12.Count, 1);
        Services.PrintElements(spansStartingWith12, "span[value^='12']");
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
}

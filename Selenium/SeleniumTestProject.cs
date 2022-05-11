using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

[TestFixture]
public class Tests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Category("Smoke Test")]
    [Category("Positive")]
    [Property("Severity", "High")]
    [Test]
    public void CheckKermifkoSite()
    {
        _driver.Navigate().GoToUrl("https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx");

        var floorWidthField = _driver.FindElement(By.Id("el_f_width"));
        floorWidthField.SendKeys("13");

        var floorLengthField = _driver.FindElement(By.Id("el_f_lenght"));
        floorLengthField.SendKeys("10");

        var roomType = _driver.FindElement(By.Id("room_type"));
        var listOfRoomTypes = new SelectElement(roomType);
        listOfRoomTypes.SelectByIndex(2);

        var heatingType = _driver.FindElement(By.Id("heating_type"));
        var listOfHeatingTypes = new SelectElement(heatingType);
        listOfHeatingTypes.SelectByValue("3");
        Assert.AreEqual("Подогрев для комфорта", listOfHeatingTypes.SelectedOption.Text, "Smth went wrong...");

        var heatLossField = _driver.FindElement(By.Id("el_f_losses"));
        heatLossField.SendKeys("10");

        var countButton = _driver.FindElement(By.CssSelector(".buttHFcalc"));
        countButton.Click();

        var floorCablePower = _driver.FindElement(By.Id("floor_cable_power"));
        Assert.AreEqual("6", floorCablePower.GetAttribute("value"), "Smth went wrong...");

        var specificFloorCablePower = _driver.FindElement(By.Id("spec_floor_cable_power"));
        Assert.AreEqual("0", specificFloorCablePower.GetAttribute("value"), "Smth went wrong...");
    }

    [Category("Smoke Test")]
    [Category("Positive")]
    [Property("Severity", "High")]
    [Test]
    public void CheckMasterskayaPolaSite()
    {
        _driver.Navigate().GoToUrl("https://masterskayapola.ru/kalkulyator/laminata.html");

        var roomLength = _driver.FindElement(By.Name("calc_roomwidth"));
        roomLength.SendKeys("5");
        
        var roomWidth = _driver.FindElement(By.Name("calc_roomheight"));
        roomWidth.SendKeys("5");
        
        var laminateLength = _driver.FindElement(By.Name("calc_lamwidth"));
        laminateLength.SendKeys("5");

        var laminateWidth = _driver.FindElement(By.Name("calc_lamheight"));
        laminateWidth.SendKeys("5");

        var laminatePerPack = _driver.FindElement(By.Name("calc_inpack"));
        laminatePerPack.SendKeys("5");

        var laminatePrice = _driver.FindElement(By.Name("calc_price"));
        laminatePrice.SendKeys("5");

        var rowOffsetElement = _driver.FindElement(By.Name("calc_bias"));
        rowOffsetElement.SendKeys("5");

        var wallIdent = _driver.FindElement(By.Name("calc_walldist"));
        wallIdent.SendKeys("5");

        var calculateButtonElement = _driver.FindElement(By.CssSelector(".btn.btn-secondary"));
        calculateButtonElement.Click();

        var directionOfLayElement = _driver.FindElement(By.XPath("//select[@name='calc_direct']"));
        var listOfDirectionsOfLay = new SelectElement(directionOfLayElement);
        Assert.That(listOfDirectionsOfLay.SelectedOption.Text == "По длине комнаты");
        
        var floorInstallationAreaElement = _driver.FindElement(By.CssSelector("#s_lam > b:nth-child(1)"));
        Assert.AreEqual("145.04", floorInstallationAreaElement.Text, "The area value is incorrect.");

        var numberOfPanelsElement = _driver.FindElement(By.CssSelector("#l_count > b:nth-child(1)"));
        Assert.AreEqual("31", numberOfPanelsElement.Text, "The number of panels is incorrect.");

        var numberOfPackagesElement = _driver.FindElement(By.CssSelector("#l_packs > b:nth-child(1)"));
        Assert.AreEqual("1", numberOfPackagesElement.Text, "The number of packages is incorrect.");

        var priceElement = _driver.FindElement(By.CssSelector("#l_price > b:nth-child(1)"));
        Assert.AreEqual("2750000", priceElement.Text, "The price is incorrect.");

        var leftoversElement = _driver.FindElement(By.CssSelector("#l_over > b:nth-child(1)"));
        Assert.AreEqual("69", leftoversElement.Text, "The number of leftovers is incorrect.");

        var cutOffsElement = _driver.FindElement(By.CssSelector("#l_trash > b:nth-child(1)"));
        Assert.AreEqual("7", cutOffsElement.Text, "The number of cut-offs is incorrect.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}

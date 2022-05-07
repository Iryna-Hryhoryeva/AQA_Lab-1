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

        var inputFormsBy = By.CssSelector(".form-control.checknumber");
        var inputForms = _driver.FindElements(inputFormsBy);

        var roomLength = inputForms[0];
        roomLength.SendKeys("5");

        var roomWidth = inputForms[1];
        roomWidth.SendKeys("5");

        var laminateLength = inputForms[2];
        laminateLength.SendKeys("5");

        var laminateWidth = inputForms[3];
        laminateWidth.SendKeys("5");

        var laminatePerPack = inputForms[4];
        laminatePerPack.SendKeys("5");

        var laminatePrice = inputForms[5];
        laminatePrice.SendKeys("5");

        var rowOffsetBy = By.CssSelector(".form-control.change_bias");
        var rowOffsetElement = _driver.FindElement(rowOffsetBy);
        rowOffsetElement.SendKeys("5");

        var wallIdent = inputForms[6];
        wallIdent.SendKeys("5");

        var calculateButtonBy = By.CssSelector(".btn.btn-secondary");
        var calculateButtonElement = _driver.FindElement(calculateButtonBy);
        calculateButtonElement.Click();

        var directionOfLayBy = By.XPath("//select[@name='calc_direct']");
        var directionOfLayElement = _driver.FindElement(directionOfLayBy);
        var listOfDirectionsOfLay = new SelectElement(directionOfLayElement);
        Assert.That(listOfDirectionsOfLay.SelectedOption.Text == "По длине комнаты");

        var floorInstallationAreaBy = By.CssSelector("#s_lam > b:nth-child(1)");
        var floorInstallationAreaElement = _driver.FindElement(floorInstallationAreaBy);
        Assert.AreEqual("145.04", floorInstallationAreaElement.Text, "The area value is incorrect.");

        var numberOfPanelsBy = By.CssSelector("#l_count > b:nth-child(1)");
        var numberOfPanelsElement = _driver.FindElement(numberOfPanelsBy);
        Assert.AreEqual("31", numberOfPanelsElement.Text, "The number of panels is incorrect.");

        var numberOfPackagesBy = By.CssSelector("#l_packs > b:nth-child(1)");
        var numberOfPackagesElement = _driver.FindElement(numberOfPackagesBy);
        Assert.AreEqual("1", numberOfPackagesElement.Text, "The number of packages is incorrect.");

        var priceBy = By.CssSelector("#l_price > b:nth-child(1)");
        var priceElement = _driver.FindElement(priceBy);
        Assert.AreEqual("2750000", priceElement.Text, "The price is incorrect.");

        var leftoversBy = By.CssSelector("#l_over > b:nth-child(1)");
        var leftoversElement = _driver.FindElement(leftoversBy);
        Assert.AreEqual("69", leftoversElement.Text, "The number of leftovers is incorrect.");

        var cutOffsBy = By.CssSelector("#l_trash > b:nth-child(1)");
        var cutOffsElement = _driver.FindElement(cutOffsBy);
        Assert.AreEqual("7", cutOffsElement.Text, "The number of cut-offs is incorrect.");
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}

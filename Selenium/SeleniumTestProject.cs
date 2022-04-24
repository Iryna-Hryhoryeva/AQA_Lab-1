using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

[TestFixture]
public class Tests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Category("Smoke Test")]
    [Category("Positive")]
    [Property("Severity", "High")]
    [Test]
    public void CheckKermifkoSite()
    {
        try
        {
            _driver.Navigate().GoToUrl("https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx");
            _wait.Until(d => d.Title == "Калькулятор электрического теплого пола Rehau");

            var floorWidthField = _driver.FindElement(By.Id("el_f_width"));
            Assert.That(floorWidthField.Displayed);
            floorWidthField.SendKeys("13" + Keys.Tab);

            var floorLengthField = _driver.FindElement(By.Id("el_f_lenght"));
            Assert.That(floorLengthField.Displayed);
            floorLengthField.SendKeys("10" + Keys.Tab);

            var roomType = _driver.FindElement(By.Id("room_type"));
            Assert.That(roomType.Displayed);
            var listOfRoomTypes = new SelectElement(roomType);
            listOfRoomTypes.SelectByIndex(2);
            Assert.True(listOfRoomTypes.SelectedOption.Enabled);

            var heatingType = _driver.FindElement(By.Id("heating_type"));
            Assert.That(heatingType.Displayed);
            var listOfHeatingTypes = new SelectElement(heatingType);
            listOfHeatingTypes.SelectByValue("3");
            Assert.AreEqual("Подогрев для комфорта", listOfHeatingTypes.SelectedOption.Text, "Smth went wrong...");

            var heatLossField = _driver.FindElement(By.Id("el_f_losses"));
            Assert.That(heatLossField.Enabled);
            heatLossField.SendKeys("10");

            var countButton = _driver.FindElement(By.CssSelector(".buttHFcalc"));
            Assert.That(countButton.Displayed && countButton.Enabled);
            countButton.Click();

            var floorCablePower = _driver.FindElement(By.Id("floor_cable_power"));
            Assert.AreEqual("6", floorCablePower.GetAttribute("value"), "Smth went wrong...");

            var specificFloorCablePower = _driver.FindElement(By.Id("spec_floor_cable_power"));
            Assert.AreEqual("0", specificFloorCablePower.GetAttribute("value"), "Smth went wrong...");
            
            Services.SayCongratulationsOrSorry(true);
        }
        catch
        {
            Services.SayCongratulationsOrSorry(false);
        }
    }

    [Category("Smoke Test")]
    [Category("Positive")] 
    [Property("Severity", "High")]
    [Test]
    public void CheckMasterskayaPolaSite()
    {
        try
        {
            _driver.Navigate().GoToUrl("https://masterskayapola.ru/kalkulyator/laminata.html");
            _wait.Until(d => d.Title == "Онлайн калькулятор ламината: расчёт на комнату со схемой укладки");

            var inputForms = _driver.FindElements(By.CssSelector(".form-control.checknumber"));

            foreach (var inputForm in inputForms)
            {
                Assert.That(inputForm.Displayed);
                inputForm.SendKeys("5");
            }

            _driver.FindElement(By.CssSelector(".btn.btn-secondary")).Click();

            var dropDown = _driver.FindElement(By.XPath("//select[@name='calc_direct']"));
            Assert.That(dropDown.Enabled);

            var floorInstallationArea = _driver.FindElement(By.CssSelector("#s_lam > b:nth-child(1)")).Text;
            Assert.AreEqual("145.04", floorInstallationArea, "The area value is incorrect.");
            var numberOfPanels = _driver.FindElement(By.CssSelector("#l_count > b:nth-child(1)")).Text;
            Assert.AreEqual("31", numberOfPanels, "The number of panels is incorrect.");
            var numberOfPackages = _driver.FindElement(By.CssSelector("#l_packs > b:nth-child(1)")).Text;
            Assert.AreEqual("1", numberOfPackages, "The number of packages is incorrect.");
            var price = _driver.FindElement(By.CssSelector("#l_price > b:nth-child(1)")).Text;
            Assert.AreEqual("2750000", price, "The price is incorrect.");
            var leftovers = _driver.FindElement(By.CssSelector("#l_over > b:nth-child(1)")).Text;
            Assert.AreEqual("69", leftovers, "The number of leftovers is incorrect.");
            var cutOffs = _driver.FindElement(By.CssSelector("#l_trash > b:nth-child(1)")).Text;
            Assert.AreEqual("7", cutOffs, "The number of cut-offs is incorrect.");

            Services.SayCongratulationsOrSorry(true);
        }
        catch 
        {
            Services.SayCongratulationsOrSorry(false);
        }
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}

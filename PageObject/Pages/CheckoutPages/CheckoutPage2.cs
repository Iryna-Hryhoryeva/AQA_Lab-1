using System;
using OpenQA.Selenium;
using PageObject.Entities;
using PageObject.Services;

namespace PageObject.Pages.CheckoutPages;

public class CheckoutPage2 : BasePage
{
    private const string _endPoint = "/checkout-step-two.html";
    public IWebElement Title = Driver.FindElement(By.ClassName("title"));
    public IWebElement SubtitleQuantity = Driver.FindElement(By.ClassName("cart_quantity_label"));
    public IWebElement SubtitleDescription = Driver.FindElement(By.ClassName("cart_desc_label"));
    public IWebElement PaymentInformation = Driver.FindElement(By.XPath("//div[@class = 'summary_info']/*[2]"));
    public IWebElement ShippingInformation = Driver.FindElement(By.XPath("//div[@class = 'summary_info']/*[4]"));
    public IWebElement ItemTotal = Driver.FindElement(By.ClassName("summary_subtotal_label"));
    public IWebElement Tax = Driver.FindElement(By.ClassName("summary_tax_label"));
    public IWebElement Total = Driver.FindElement(By.ClassName("summary_total_label"));
    public IWebElement FinishButton = Driver.FindElement(By.ClassName(Buttons.ContinueButtonClassName));
    
    public CheckoutPage2(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + _endPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return FinishButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }
}

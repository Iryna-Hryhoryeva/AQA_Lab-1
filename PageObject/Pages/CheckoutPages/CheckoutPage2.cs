using System;
using OpenQA.Selenium;
using PageObject.Buttons;
using PageObject.Services;

namespace PageObject.Pages.CheckoutPages;

public class CheckoutPage2 : BasePage, IContinueButton, IGoBackButton, IHaveCartButton, IHaveBurgerButton,
    IHaveSocialNetworks
{
    private const string _endPoint = "/checkout-step-two.html";
    private static readonly By _titleBy = By.ClassName("title");
    private static readonly By _subtitleQuantityBy = By.ClassName("cart_quantity_label");
    private static readonly By _subtitleDescription = By.ClassName("cart_desc_label");
    private static readonly By _paymentInformation = By.XPath("//div[@class = 'summary_info']/*[2]");
    private static readonly By _shippingInformation = By.XPath("//div[@class = 'summary_info']/*[4]");
    private static readonly By _itemTotalBy = By.ClassName("summary_subtotal_label");
    private static readonly By _taxBy = By.ClassName("summary_tax_label");
    private static readonly By _totalBy = By.ClassName("summary_total_label");

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

    public IWebElement Title = Driver.FindElement(_titleBy);
    public IWebElement SubtitleQuantity = Driver.FindElement(_subtitleQuantityBy);
    public IWebElement SubtitleDescription = Driver.FindElement(_subtitleDescription);
    public IWebElement PaymentInformation = Driver.FindElement(_paymentInformation);
    public IWebElement ShippingInformation = Driver.FindElement(_shippingInformation);
    public IWebElement ItemTotal = Driver.FindElement(_itemTotalBy);
    public IWebElement Tax = Driver.FindElement(_taxBy);
    public IWebElement Total = Driver.FindElement(_totalBy);
    public IWebElement FinishButton = IContinueButton.FindContinueButton(Driver);
}

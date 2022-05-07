using NUnit.Framework;
using PageObject.Tests.CheckoutTests;

namespace PageObject.Tests.EndToEndTests;

public class OrderSomeProductTest : BaseTest
{
    [Property("Comment", "Failed to add negative tests here, so I'm not sure the test can be called end-2-end.")]
    [Test]
    public void OrderOneProduct()
    {
        Checkout3Test.GoBackToProductsList();
    }
}

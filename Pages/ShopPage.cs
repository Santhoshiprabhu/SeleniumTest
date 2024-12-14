using OpenQA.Selenium;

namespace SeleniumTest.Pages
{
    public class ShopPage
    {
        private IWebDriver _driver;

        public ShopPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        public IWebElement CartLink => _driver.FindElement(By.LinkText("Cart"));

        // Methods
        public void AddProductToCart(string productId, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var productBuyButton = _driver.FindElement(By.XPath($"//li[@id='{productId}']//a[text()='Buy']"));
                productBuyButton.Click();
            }
        }

        public void GoToCartPage()
        {
            CartLink.Click();
        }
    }
}
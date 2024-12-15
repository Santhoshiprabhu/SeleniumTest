using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Pages;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class TestCase3
    {
        [Test]
        public void Test3()
        {
            // Use WebDriverManager to handle ChromeDriver setup
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/shop");
                driver.Manage().Window.Maximize();

                var shopPage = new ShopPage(driver);
                var cartPage = new CartPage(driver);

                // Add products to cart
                shopPage.AddProductToCart("product-2", 2); // Stuffed Frog
                shopPage.AddProductToCart("product-4", 5); // Fluffy Bunny
                shopPage.AddProductToCart("product-7", 3); // Valentine Bear

                // Navigate to cart
                shopPage.GoToCartPage();

                // Retrieve prices and subtotals for each product
                var priceStuffedFrog = cartPage.GetProductPrice("Stuffed Frog");
                var priceFluffyBunny = cartPage.GetProductPrice("Fluffy Bunny");
                var priceValentineBear = cartPage.GetProductPrice("Valentine Bear");

                var subtotalStuffedFrog = cartPage.GetProductSubtotal("Stuffed Frog");
                var subtotalFluffyBunny = cartPage.GetProductSubtotal("Fluffy Bunny");
                var subtotalValentineBear = cartPage.GetProductSubtotal("Valentine Bear");

                // Retrieve the total price
                var total = cartPage.GetTotal();

                // Output the individual prices, subtotals, and total
                Console.WriteLine($"Stuffed Frog Price: {priceStuffedFrog}, Subtotal: {subtotalStuffedFrog}");
                Console.WriteLine($"Fluffy Bunny Price: {priceFluffyBunny}, Subtotal: {subtotalFluffyBunny}");
                Console.WriteLine($"Valentine Bear Price: {priceValentineBear}, Subtotal: {subtotalValentineBear}");
                Console.WriteLine($"Total Price: {total}");

                // Add assertions for verifying total
                decimal expectedTotal = (priceStuffedFrog * 2) + (priceFluffyBunny * 5) + (priceValentineBear * 3);
                if (total == expectedTotal)
                {
                    Console.WriteLine("Total price verification passed.");
                }
                else
                {
                    Console.WriteLine($"Total price verification failed. Expected: {expectedTotal}, Found: {total}");
                }
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}

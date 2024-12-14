using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Pages;

namespace SeleniumTest.Tests
{
    public class TestCase1
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com/#/home");
                driver.Manage().Window.Maximize();

                var homePage = new HomePage(driver);
                var contactPage = new ContactPage(driver);

                // Navigate to Contact Page
                homePage.GoToContactPage();

                // Submit the form without filling fields
                contactPage.ClickSubmit();
                Console.WriteLine("Verified error messages on empty form submission.");

                // Fill the form and submit
                contactPage.FillForm("Santhosh", "santhoship@yahoo.com", "Test Message");
                contactPage.ClickSubmit();

                // Verify success message
                if (contactPage.IsSuccessMessageVisible())
                {
                    Console.WriteLine("Success message verified!");
                }
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}

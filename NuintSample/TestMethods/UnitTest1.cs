using NunitSample.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitSample.TestMethods
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }

        [Test]
        [Order(0)]
        public void textBoxVerification()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NevigateToElements("Elements");

            ElementsPage elePage=new ElementsPage(driver);
            elePage.NavigateToElementType("Text Box");
            string eleVerif = "Text Box";
            Assert.AreEqual(eleVerif, elePage.TextVerification("Text Box"));

            elePage.TextBoxInfo();
            string name1 = "ABC";
            Assert.IsTrue(elePage.TextBoxInfoVerification("ABC").Contains(name1));
        }
    }
}
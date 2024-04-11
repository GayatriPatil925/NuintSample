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
        public void TextBoxVerification()
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

        [Test]
        [Order(1)]
        public void TheckboxVerification()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NevigateToElements("Elements");

            ElementsPage elePage = new ElementsPage(driver);
            elePage.NavigateToElementType("Check Box");
            string eleVerif = "Check Box";
            Assert.AreEqual(eleVerif, elePage.TextVerification("Check Box"));

            List<string> SelectedCategories = new List<string> { "desktop", "notes", "commands" };
            elePage.CheckBoxSelection(SelectedCategories);
        }

        [Test]
        [Order(2)]
        public void Alert()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NevigateToElements("Alerts");

            Alert alert = new Alert(driver);
            alert.NavigateToAlertType("Alerts");
            string eleVerif = "Alerts";
            Assert.AreEqual(eleVerif, alert.AlertVerification("Alerts"));

            alert.NormAlert();
            alert.TimeAlert();
        }

        
        [Test]//way to pass multiple data to a test method
       // [TestCase("Elements")]
       // [TestCase("Alerts")]

        //another way to pass multiple data using iEnumerable 
        [TestCaseSource("AddDataConfig")]        
        [Order(3)]
        public void HomeTry(string ele)
        {
            HomePage homePage = new HomePage(driver);
            homePage.NevigateToElements(ele);
        }
        //function to initialize multiple data for test method
        public static IEnumerable<TestCaseData> AddDataConfig() 
        {
            yield return new TestCaseData("Elements");
            yield return new TestCaseData("Alerts");
        }
    }
}
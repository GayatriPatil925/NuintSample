using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitSample.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        //this is page object modeling pattern
        //private IWebElement elements => driver.FindElement(By.XPath("//h5[contains(text(),'Forms')]"));

        public void NevigateToElements(string element)
        {
            Thread.Sleep(3000);
            IWebElement elements = driver.FindElement(By.XPath($"//h5[contains(text(),'{element}')]"));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", elements);
            elements.Click();
        }
    }
}

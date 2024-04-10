using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NunitSample.PageObjects
{
    public class ElementsPage
    {
        private IWebDriver driver;
        private IWebElement userName => driver.FindElement(By.Id("userName"));
        private IWebElement userEmail => driver.FindElement(By.Id("userEmail"));
        private IWebElement currentAdd => driver.FindElement(By.Id("currentAddress"));
        private IWebElement perAdd => driver.FindElement(By.Id("permanentAddress"));
        private IWebElement Submit => driver.FindElement(By.Id("submit"));

        public ElementsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToElementType(string eleType)
        {
            IWebElement elements = driver.FindElement(By.XPath("//span[@class='text' and contains(text(),'" + eleType + "')]"));
            var js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("arguments[0].scrollIntoView(true)", elements);
            elements.Click();
        }

        public string TextVerification(string eleType)
        {
            return driver.FindElement(By.XPath("//h1[contains(text(),'" + eleType + "')]")).Text;
        }

        public void TextBoxInfo()
        {
            userName.SendKeys("ABC");
            userEmail.SendKeys("abc@gmail.com");
            currentAdd.SendKeys("Yerwada");
            perAdd.SendKeys("Agra");
            Submit.Click();
        }

        public string TextBoxInfoVerification(string userName)
        {
            return driver.FindElement(By.Id("name")).Text;
        }
    }
}

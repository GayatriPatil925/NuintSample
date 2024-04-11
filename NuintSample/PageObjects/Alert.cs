using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitSample.PageObjects
{
   public class Alert
    {
        private IWebDriver driver;
        IJavaScriptExecutor js;
        //pageobject modeling
        private IWebElement normAlert => driver.FindElement(By.XPath("//button[@id='alertButton']"));
        //pageFactory
        [FindsBy(How = How.XPath, Using = "//button[@id='timerAlertButton']")]
        private IWebElement timeAlert;

        public Alert(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            js = (IJavaScriptExecutor)driver;
        }
        public void NavigateToAlertType(string eleType)
        {
            IWebElement elements = driver.FindElement(By.XPath("//span[@class='text' and contains(text(),'" + eleType + "')]"));
            js.ExecuteScript("arguments[0].scrollIntoView(true)", elements);
            elements.Click();
        }

        public string AlertVerification(string eleType)
        {
            return driver.FindElement(By.XPath("//h1[contains(text(),'" + eleType + "')]")).Text;
        }

        public void NormAlert()
        {
           normAlert.Click();
           driver.SwitchTo().Alert().Accept();
        }

        public void TimeAlert()
        {
            timeAlert.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();
        }

    }
}

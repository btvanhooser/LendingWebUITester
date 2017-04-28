using OpenQA.Selenium;
using System;

namespace Lending_Web_UI_Tester.Page_Models
{
    public class ThankYouPage
    {
        public static bool HeaderExists(IWebDriver driver)
        {
            try
            {
                var header = Header(driver);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        #region Getters
        private static IWebElement Header(IWebDriver driver)
        {
            return driver.FindElement(By.Id("ThankYouHeader"));
        }

        private static IWebElement Message(IWebDriver driver)
        {
            return driver.FindElement(By.Id("statusMessage"));
        }
        #endregion
    }
}

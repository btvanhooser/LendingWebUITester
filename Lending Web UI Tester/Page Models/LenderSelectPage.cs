using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lending_Web_UI_Tester.Page_Models
{
    public class LenderSelectPage
    {
        public static bool ChooseLender(IWebDriver driver, string lenderToSelect)
        {
            try
            {
                var submitButton = SubmitButton(driver);
                var lenderDropDown = LenderDropDown(driver);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var selectElement = new SelectElement(lenderDropDown);
                selectElement.SelectByText(lenderToSelect);

                submitButton.Click();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        #region Getters
        private static IWebElement SubmitButton(IWebDriver driver)
        {
            return driver.FindElement(By.Id("submitButton"));
        }

        private static IWebElement LenderDropDown(IWebDriver driver)
        {
            return driver.FindElement(By.Id("lenderDropDown"));
        }
        #endregion
    }
}

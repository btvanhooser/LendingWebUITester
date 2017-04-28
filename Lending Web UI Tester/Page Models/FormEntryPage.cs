using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lending_Web_UI_Tester.Page_Models
{
    public class FormEntryPage
    {
        public static bool FillApplication(IWebDriver driver, Dictionary<string,string> pageParams)
        {
            return (FillLoanInfoSection(driver, pageParams) &&
            FillApplicantInfoSection(driver, pageParams) &&
            FillEmploymentInfoSection(driver, pageParams)) ;
        }

        public static bool VerifyTitle(IWebDriver driver, string expectedName)
        {
            return LenderWelcomePrompt(driver).Text.Equals(expectedName);
        }

        #region Interactions
        public static bool FillLoanInfoSection(IWebDriver driver, Dictionary<string, string> sectionParams)
        {
            try
            {
                var amountField = Amount(driver);
                var termField = Term(driver);

                amountField.SendKeys(sectionParams["Amount"]);
                termField.SendKeys(sectionParams["Term"]);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool FillApplicantInfoSection(IWebDriver driver, Dictionary<string, string> sectionParams)
        {
            try
            {
                var firstName = FirstName(driver);
                var lastName = LastName(driver);
                var ssn = SSN(driver);
                var phone = Phone(driver);
                var email = Email(driver);

                firstName.SendKeys(sectionParams["First Name"]);
                lastName.SendKeys(sectionParams["Last Name"]);
                ssn.SendKeys(sectionParams["SSN"]);
                phone.SendKeys(sectionParams["Phone"]);
                email.SendKeys(sectionParams["Email"]);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool FillEmploymentInfoSection(IWebDriver driver, Dictionary<string, string> sectionParams)
        {
            try
            {
                var employer = Employer(driver);
                var income = Income(driver);
                var incomeFreq = IncomeFrequency(driver);
                var isBranchEmployee = BranchEmployee(driver);
                var employeeID = EmployeeID(driver);

                employer.SendKeys(sectionParams["Employer"]);
                income.SendKeys(sectionParams["Income"]);

                var selectElement = new SelectElement(incomeFreq);
                selectElement.SelectByText(sectionParams["Income Frequency"]);

                if (sectionParams["Is Branch Employee"].Equals("Yes"))
                {
                    isBranchEmployee.Click();
                    employeeID.SendKeys(sectionParams["Employee ID"]);
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool SubmitApplication(IWebDriver driver)
        {
            try
            {
                var submitButton = SubmitButton(driver);
                submitButton.Click();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Getters
        private static IWebElement LenderWelcomePrompt(IWebDriver driver)
        {
            return driver.FindElement(By.Id("LenderWelcomePrompt"));
        }
        
        private static IWebElement Amount(IWebDriver driver)
        {
            return driver.FindElement(By.Id("amount"));
        }

        private static IWebElement Term(IWebDriver driver)
        {
            return driver.FindElement(By.Id("term"));
        }

        private static IWebElement FirstName(IWebDriver driver)
        {
            return driver.FindElement(By.Id("firstName"));
        }

        private static IWebElement LastName(IWebDriver driver)
        {
            return driver.FindElement(By.Id("lastName"));
        }

        private static IWebElement SSN(IWebDriver driver)
        {
            return driver.FindElement(By.Id("ssn"));
        }

        private static IWebElement Email(IWebDriver driver)
        {
            return driver.FindElement(By.Id("email"));
        }

        private static IWebElement Phone(IWebDriver driver)
        {
            return driver.FindElement(By.Id("phone"));
        }

        private static IWebElement Employer(IWebDriver driver)
        {
            return driver.FindElement(By.Id("employer"));
        }

        private static IWebElement Income(IWebDriver driver)
        {
            return driver.FindElement(By.Id("income"));
        }

        private static IWebElement IncomeFrequency(IWebDriver driver)
        {
            return driver.FindElement(By.Id("incomeFreq"));
        }

        private static IWebElement BranchEmployee(IWebDriver driver)
        {
            return driver.FindElement(By.Id("isBranchEmployee"));
        }

        private static IWebElement EmployeeID(IWebDriver driver)
        {
            return driver.FindElement(By.Id("employeeID"));
        }

        private static IWebElement SubmitButton(IWebDriver driver)
        {
            return driver.FindElement(By.Id("submitButton"));
        }
        #endregion
    }
}

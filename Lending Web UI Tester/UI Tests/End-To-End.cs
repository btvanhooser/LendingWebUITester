using Lending_Web_UI_Tester.Page_Models;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Lending_Web_UI_Tester.UI_Tests
{
    public static class End_To_End
    {
        public static void BasicTest(IWebDriver driver, List<Dictionary<string,string>> testParams)
        {
            foreach (var iterationData in testParams)
            {
                //TODO Replace this url
                driver.Url = "https://simple-lending-web-app.herokuapp.com";

                LenderSelectPage.ChooseLender(driver, iterationData["Lender Name"]);

                FormEntryPage.VerifyTitle(driver, iterationData["Lender Name"]);
                FormEntryPage.FillApplication(driver, iterationData);
                FormEntryPage.SubmitApplication(driver);

                ThankYouPage.HeaderExists(driver);
            }
        }
    }
}

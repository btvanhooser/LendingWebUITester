using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Lending_Web_UI_Tester.UI_Tests;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace Lending_Web_UI_Tester
{
    class LendingWebAppTester
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            End_To_End.BasicTest(driver, ReadExcel("EndToEnd"));
            driver.Quit();
        }

        static List<Dictionary<string, string>> ReadExcel(string testname)
        {
            var result = new List<Dictionary<string, string>>();

            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(Path.Combine(Environment.CurrentDirectory, @"..\..\Excel\TestData.xlsx"));
            _Worksheet xlWorksheet = xlWorkbook.Sheets[testname];
            Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                var dict = new Dictionary<string, string>();

                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        dict.Add(xlRange.Cells[1, j].Value2.ToString(), xlRange.Cells[i, j].Value2.ToString());
                }

                result.Add(dict);
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return result;
        }
    }
}

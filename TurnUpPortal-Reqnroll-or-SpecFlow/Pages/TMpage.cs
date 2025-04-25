using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using TurnUpPortal_Reqnroll_or_SpecFlow.Utilites;

namespace TurnUpPortal_Reqnroll_or_SpecFlow.Pages
{
    public class TMpage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            try
            {
                //  Click on Create New button
                IWebElement CreateNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                CreateNewButton.Click();
            }
            catch (Exception ex)

            {
                Assert.Fail("Create New Button has not been found");
            }
            // Identify Dropdown  and select Time option
            IWebElement timeDropdownOPtion = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            timeDropdownOPtion.Click();
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Type code in code Textbox
            IWebElement codeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            codeTextbox.SendKeys("123A");

            // Type description in description text box
            IWebElement descriptionTextBox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextBox.SendKeys("This is my first Time Order");

            // **Type price in price Text box Note:Below code line extra due to overlapping code
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();
            IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            priceTextBox.SendKeys("12");
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 2);

            // Click on Save Button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(9000);

            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 9);
            //Check if Time Record is created successfully or not 
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(9000);
            try
            {
                IWebElement NewCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(NewCode.Text == "123A", "Time Record is not created! Test is Failed");
            }
            catch (Exception ex)
            {
                Assert.Fail("NewCode is not found");
            }

            //if (NewCode.Text == "123A")
            //{
            //    Assert.Pass("new Time Record is created! Test is passed");
            //}                                                   
            //else
            //{
            //    Assert.Fail("Time Record is not created! Test is Failed");
            //}

        }
        public void EditTimeRecord(IWebDriver driver)
        {   Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(4000);

           //  Edit the Time Record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(3000);

            // Identify Code Text box and change text to TA-FAR
            IWebElement editCodeText = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            editCodeText.Clear();
            editCodeText.SendKeys("TA-FAR");

            // Identify Description text box and enter description
            IWebElement descriptionTextBoxM = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextBoxM.Clear();
            descriptionTextBoxM.SendKeys("Time Record is now Edited");

            // **Identify Price Text box and enter price value
            // As this text box is with overlapping code so create first code for highlight the price
            // field and then create code to enter the text
            IWebElement overLapedField = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            overLapedField.Click();
            IWebElement priceTextBoxM = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            priceTextBoxM.SendKeys(Keys.Control + "a");
            priceTextBoxM.SendKeys(Keys.Delete);
            priceTextBoxM.SendKeys("20");

            // Identify Save Button and click on it
            IWebElement saveButtonclick = driver.FindElement(By.Id("SaveButton"));
            saveButtonclick.Click();
            Thread.Sleep(8000);

            // Validate if Time Record is Edited or Not
            IWebElement EditedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (EditedCode.Text == "TA-FAR")
            {
                Console.WriteLine("Time Record is Successfully Edited! Test is Passed!");
            }
            else

            {
                Console.WriteLine("Time Record is not Edited! Test is Failed");
            }

        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(4000);

            // Click on the Delete Button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);

            // Switch to Alert window to press Ok in Delete box
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(12000);
            // driver.Navigate().Refresh();

            // Check if Record is deleted or not
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (deletedCode.Text != "TA-FAR")
            {
                Console.WriteLine("Record is deleted succeessfully! Test is Passed");
            }
            else
            {
                Console.WriteLine("Record is not deleted successfully so Test Is Failed");
            }




        }
    }
}

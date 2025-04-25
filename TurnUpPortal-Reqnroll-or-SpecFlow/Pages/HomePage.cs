using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TurnUpPortal_Reqnroll_or_SpecFlow.Utilites;

namespace TurnUpPortal_Reqnroll_or_SpecFlow.Pages
{
    public class HomePage
    {   
        public void VerifyUserInHomePage(IWebDriver driver)
        {
            //  Verify if user login sucessfully or not
            IWebElement HelloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if (HelloHari.Text == "Hello hari!")
            {
                Console.WriteLine("User is login successfully! Test is Passed");
            }
            else

            {
                Console.WriteLine("User is not successfully login! Test is Failed");
            }

        }
        public void NavigateToTMPage(IWebDriver driver) 
        {
            // Identify adminstration drop down and perform action click
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10);

            // Click on option Time and Material
            IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeAndMaterialOption.Click();
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using TurnUpPortal_Reqnroll_or_SpecFlow.Utilites;

namespace TurnUpPortal_Reqnroll_or_SpecFlow.Pages
{
    public class LoginPage
    {
        // Methods that allow users to login to website TurnupPortal

        public void LoginActions(IWebDriver driver) 
        {
            // Step-2   Launch Turnup Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io");
            Thread.Sleep(4000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            try
            {
                // Step-3 Identify username text box and enter valid user name
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception ex)
            {
                Assert.Fail("User text box not identified");
            }
            Wait.WaitToBeVisible(driver, "Id", "Password", 7);

            // Step-4  Identify password textbox and enter valid password
            IWebElement paswordTextbox = driver.FindElement(By.Id("Password"));
            paswordTextbox.SendKeys("123123");


            // Step-5   Identify Login button and perform action click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
        }

    }
}

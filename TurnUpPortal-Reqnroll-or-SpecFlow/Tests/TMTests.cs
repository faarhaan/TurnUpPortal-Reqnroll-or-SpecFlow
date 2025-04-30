using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal_Reqnroll_or_SpecFlow.Pages;
using TurnUpPortal_Reqnroll_or_SpecFlow.Utilites;

namespace TurnUpPortal_Reqnroll_or_SpecFlow.Tests
{
    [TestFixture]
    public class TMTests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            // To Handle leak password Detection
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            //  Open Chrome Browser
             driver = new ChromeDriver(options);
            // LoginPage Object initiallization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj.LoginActions(driver);

            // HomePage Object initilization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyUserInHomePage(driver);
            homePageObj.NavigateToTMPage(driver);
        }
        [Test, Order(1)]
        public void CreateTime_Test()
        {

            // TMpage Object initialization and definition
            TMpage tMpageObj = new TMpage();
            tMpageObj.CreateTimeRecord(driver);
        }
        [Test, Order(2), Description("This test update the Time/Material record with valid details")]
        public void EditTime_Test(IWebDriver driver, String Code)
        {
            // Edit Time Record
            TMpage tMpageObj = new TMpage();
            tMpageObj.EditTimeRecord(driver, Code);
        }
        [Test, Order(3)]
        public void DeleteTime_Test()
        {
            // Delete Time Record
            TMpage tMpageObj = new TMpage();
            tMpageObj.DeleteTimeRecord(driver);
        }
        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit(); 
         }
    }


}

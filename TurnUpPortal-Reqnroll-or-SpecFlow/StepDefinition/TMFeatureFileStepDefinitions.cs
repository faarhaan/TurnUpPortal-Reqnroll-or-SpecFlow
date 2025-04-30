using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using TurnUpPortal_Reqnroll_or_SpecFlow.Pages;
using TurnUpPortal_Reqnroll_or_SpecFlow.Utilites;

namespace TurnUpPortal_Reqnroll_or_SpecFlow.StepDefinition
{
    [Binding]
    public class TMFeatureFileStepDefinitions : CommonDriver
    {
        [BeforeScenario]
        public void SetupSteps()
        {
            // To Handle leak password Detection
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            //  Open Chrome Browser
            driver = new ChromeDriver(options);

        }
        [Given("I Login to the Portal Successfully")]
        public void GivenILoginToThePortalSuccessfully()
        {
            // LoginPage Object initiallization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj.LoginActions(driver);
        }

        [When("I navigate to Time and Material Page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // HomePage Object initilization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyUserInHomePage(driver);
            homePageObj.NavigateToTMPage(driver);
        }

        [When("I create the time record successfully")]
        public void WhenICreateTheTimeRecordSuccessfully()
        {

            // TMpage Object initialization and definition
            TMpage tMpageObj = new TMpage();
            tMpageObj.CreateTimeRecord(driver);
        }

        [Then("Reecord should be created successfully")]
        public void ThenReecordShouldBeCreatedSuccessfully()
        {
            TMpage tMpageObj = new TMpage();
            String newCode = tMpageObj.GetCode(driver);
            String newDescription = tMpageObj.GetDescription(driver);
            String newPrice =  tMpageObj.GetPrice(driver);

            Assert.That(newCode == "123A", "Time Record is not created! Test is Failed");
            Assert.That(newDescription == "This is my first Time Order", "Expected and Actual description don't match");
            Assert.That(newPrice == "$12.00", "Actual Price and Expected Price do not match");
        }
        [When("I update the {string} on an existing Time Record")]
        public void WhenIUpdateTheOnAnExistingTimeRecord(string Code)
        {
            TMpage tMpageObj = new TMpage();
            tMpageObj.EditTimeRecord(driver, Code);
        }

        [Then("the record should have the updated {string}")]
        public void ThenTheRecordShouldHaveTheUpdated(string Code)
        {
            TMpage tMpageObj = new TMpage();
           string editedCode = tMpageObj.GeteditedCode(driver);
           Assert.That(editedCode == Code, "Expected Edited code doesnot match with Actual Edited code");
        }
        [AfterScenario]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}

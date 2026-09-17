using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using Reqnroll.CommonModels;
using System;
using System.Reflection.Emit;
using System.Threading;
using TestProject1.Drivers;
using TestProject1.Hooks;
using TestProject1.Pages;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestProject1
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly GooglePage DutumPage;

        public LoginStepDefinitions()
        {
            driver = DriverFactory.GetDriver();
            DutumPage = new GooglePage(driver);
        }

        [Given("the user is on the homepage")]
        public void GivenTheBrowserIsLaunched()
        {
            // Browser already launched in Hooks




            Hooks.Hooks.scenario.Value!.Info("Browser launched successfully");
        }

        [When("Enter the valid username and password")]
        public void WhenTheUserEnterCredentials()
        {
            DutumPage.NavigateToQaUrl();
            DutumPage.EnterCredential("viswa.s@tawnytech.in", "VJviswa@107");
            DutumPage.ClickLoginButton();


            Thread.Sleep(2000); // Wait for 2 seconds to see the search results

            Hooks.Hooks.scenario.Value!.Pass("Entered valid username and password");
        }
        [When("Enter the valid Dutum username and password")]

        public void WhenEnterTheValidDutumUsernameAndPassword()
        {
            DutumPage.NavigateToQaUrl();

        }
        [Then("the page should be navigated to the dashboard")]

        public void ThenThePageShouldBeNavigatedToTheDashboard()
        {
            Assert.IsTrue(driver.Url.Contains("dashboard"), "User is not navigated to the dashboard");
            Console.WriteLine("Page Title: " + DutumPage.GetPageTitle());

            Hooks.Hooks.scenario.Value!.Pass("Page title displayed successfully");
        }



        [Then("The username should be displayed on the top right corner")]
        public void TheUsernameShouldBeDisplayedOnTheTopRightCorner()
        {


            string actualusername = DutumPage.GetLoggedInUsername();
            Assert.IsTrue(actualusername.Contains("viswa"), "Logged in username is not displayed correctly");
            Console.WriteLine(actualusername);
        }

        [Then("the user should redirected to the dashboard page")]
        public void ThenTheUserShouldRedirectedToTheDashboardPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("dashboard"));
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.Url.Contains("dashboard"), "User is not redirected to the dashboard page");
                Console.WriteLine("Page Title: " + DutumPage.GetPageTitle());
                Assert.IsTrue(driver.Title.Contains("Dutam"), "Page title does not contain 'Dashboard'");

            });
            Hooks.Hooks.scenario.Value!.Pass("User is redirected to the dashboard page successfully");
        }

        [Then("Logout button should be visible")]
        public void ThenLogoutButtonShouldBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userclick = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'viswa ')]")));
            userclick.Click();
            IWebElement logoutButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'Logout')]")));
            Assert.IsTrue(logoutButton.Displayed, "Logout button is not visible");
            Hooks.Hooks.scenario.Value!.Pass("Logout button is visible successfully");
        }



        [When("Enter the invalid username {string} and password {string}")]

        public void WhenTheUserEnterMultipleCredentials(string username, string password)
        {

            Console.WriteLine(driver.Url);
            Console.WriteLine(driver.Title);
            DutumPage.EnterCredential(username, password);
            DutumPage.ClickLoginButton();


            Thread.Sleep(2000); // Wait for 2 seconds to see the search results

            Hooks.Hooks.scenario.Value!.Info(
                 $"Entered Username: {username} and Password: {password}");
        }

        [Then("the error message should be displayed")]
        public void ThenTheErrorMessageShouldBe_Displayed()
        {

            Assert.IsTrue(DutumPage.ShowErrorMessage(), "error message is not Displayed");
            Console.WriteLine("Page Title: " + DutumPage.GetPageTitle());
            string screenshotPath =
            ScreenshotHelper.TakeScreenshot(driver, "FinalResult");

            Hooks.Hooks.scenario.Value!.Pass("The error message is displayed successfully", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
        }
        [When("Enter the valid Dutum Advancedbutton and click proceed")]

        public void WhenEnterTheValidDutumAdvancedbuttonAndClickProceed()
        {
            DutumPage.NavigateToQaUrl();
            DutumPage.ClickAdvancedButton();
            DutumPage.ClickProceedLink();
        }
        [Then("the page should be navigated to Dutum Main page")]
        public void ThenThePageShouldBeNavigatedToDutumMainPage()
        {
            DutumPage.DutumMainPage();

            Assert.IsTrue(driver.Url.Contains("home"), "User is not navigated to the Dutum Main page");

            Hooks.Hooks.scenario.Value!.Pass("Page title displayed successfully");
        }
        [When("Click on the Admin button")]
        public void ClickOnTheAdminButton()
        {
            DutumPage.ClickAdminLoginButton();

            Thread.Sleep(2000); // Wait for 2 seconds to see the search results

        }
        [When("Enter the valid main username and password")]
        public void WhenEnterTheValidMainUsernameAndPassword()
        {
            DutumPage.EnterCredential("viswa.s@tawnytech.in", "VJviswa@107");
            DutumPage.ClickLoginButton();

            Thread.Sleep(2000); // Wait for 2 seconds to see the search results

            Hooks.Hooks.scenario.Value!.Pass("Entered valid username and password");
        }
           }
}
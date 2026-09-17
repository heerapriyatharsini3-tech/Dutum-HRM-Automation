using AventStack.ExtentReports;
using NPOI.SS.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Drivers;
using TestProject1.Pages;

namespace TestProject1
{
    [Binding]
    public class UserStepDefinition
    {
        private readonly IWebDriver driver;
        private readonly GooglePage DutumPage;

        public UserStepDefinition()
        {
            driver = DriverFactory.GetDriver();
            DutumPage = new GooglePage(driver);
        }
        [When("click the user image button on the top right corner")]
        public void WhenClickTheUserImageButtonOnTheTopRightCorner()
        {
            DutumPage.ClickUserImageButton();
            Thread.Sleep(2000); // Wait for 2 seconds to see the search results
        }
        [Then("In dropdown click on logout button")]
        public void ThenInDropdownClickOnLogoutButton()
        {
            DutumPage.ClickLogoutButton();
            Thread.Sleep(2000); // Wait for 2 seconds to see the search results
            Console.WriteLine("The page is logged out successfully and navigated to the login page");

        }
        [Then("the user should be redirected to the home page")]
        public void ThenTheUserShouldBeRedirectedToTheHomePage()
        {
            Assert.IsTrue(driver.Url.Contains("home"), "User is not navigated to the home page after logout");
            Hooks.Hooks.scenario.Value!.Pass("User is logged out and navigated to the login page successfully");

        }


        [Then("click user list page will be display on the screen")]
        public void ThenClickUserListPageWillBeDisplayOnTheScreen()
        {
            Assert.IsTrue(driver.Url.Contains("users"), "User list page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("User list page is displayed successfully");
        }
        [When("Click on the user list button")]
        public void WhenClickOnTheUserListButton()
        {
            DutumPage.ClickUserButton();
            Thread.Sleep(2000); // Wait for 2 seconds to see the search results
        }
        [Then("the add user page will be displayed")]

        public void ThenTheAddUserPageWillBeDisplayed()
        {
            IWebElement adduserpage = driver.FindElement(By.XPath("///label[text()='Name']//preceding::span[text()='Add User'][1]"));
            Assert.IsTrue(adduserpage.Displayed, "Add user page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("Add user page is displayed successfully");
        }
        [When("click on the Add_User button")]

        public void WhenClickOnTheAdd_UserButton()
        {
            DutumPage.ClickAdd_UserButton();
            Thread.Sleep(2000); // Wait for 2 seconds to see the search results
        }
        [Then("add user page will be display on screen")]

        public void WhenclickontheAdd_Userbutton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement Add_UserPage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Name']")));
            Assert.IsTrue(Add_UserPage.Displayed, "Add_User Main Page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("Add_User Main Page is displayed successfully");

        }
        [When("enter the mandatory fields")]
        public void WhenEnterTheMandatoryField(Reqnroll.Table table)
        {
            UserDetails user = table.CreateInstance<UserDetails>();



            DutumPage.EnterMandatoryFields(user);
        }
        [StepDefinition("click on the save button")]
        public void WhenClickOnTheSaveButton()
        {
            DutumPage.ClickSaveButton();
            Thread.Sleep(3000); // Wait for 3 seconds to see the search results
            string screenshotPath =
            ScreenshotHelper.TakeScreenshot(driver, "FinalResult");

            Hooks.Hooks.scenario.Value!.Pass(
                "Final page displayed successfully",
                MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
        }

        [When("enter the mandatory fields and with name field accept alphanumeric value")]
        public void WhenEnterTheMandatoryFieldsAndWithNameFieldAcceptAlphanumericValue()
        {
            UserDetails user = new UserDetails
            {
                Name = "m0ti",
                Email = "velanvanthan.com",
                Mobile = "9790776860",
                Assign_Client = "Aarding",
                Gender = "Female",
                Assign_Skill = "HiCAD Modeling (Machine Building)",
                Account_Name = "Heera",
                Account_Email = "moti4462@gmail.com",
                Designation = "Junior Project Engineer",
                Joined_Date = "23",

                Reporting_To = "superadmin",
                Role = "IT Admin",
                Employee_Code = "EMP123",
                Salary = "50000",
                Account_Number = "1234567890",
                Account_Phone = "9876543210"

            };

            DutumPage.EnterMandatoryFields(user);

        }

        [When("enter the mandatory fields and with name field accept numerical value")]
        public void WhenEnterTheMandatoryFieldsAndWithNameFieldAcceptNumericValue()
        {
            UserDetails user = new UserDetails
            {
                Name = "12453",
                Email = "heerayatha@gmail.com",
                Mobile = "9677185680",
                Assign_Client = "Aarding",
                Gender = "Female",
                Assign_Skill = "HiCAD Modeling (Machine Building)",
                Account_Name = "Heera",
                Account_Email = "heerayatha@gmail.com",
                Designation = "Junior Project Engineer",
                Joined_Date = "23",

                Reporting_To = "superadmin",
                Role = "IT Admin",
                Employee_Code = "EMP123",
                Salary = "50000",
                Account_Number = "1234567890",
                Account_Phone = "9876543210"

            };

            DutumPage.EnterMandatoryFields(user);

        }

        [When("Verify duplicate Email is not allowed")]
        public void WhenVerifyDuplicateEmailIsNotAllowed()
        {
            UserDetails user = new UserDetails
            {
                Name = "Heera",
                Email = "heerayatha@gmail.com",
                Mobile = "9677185680",
                Assign_Client = "Aarding",
                Gender = "Female",
                Assign_Skill = "HiCAD Modeling (Machine Building)",
                Account_Name = "Heera",
                Account_Email = "test@example.com",
                Designation = "Junior Project Engineer",
                Joined_Date = "23",

                Reporting_To = "superadmin",
                Role = "IT Admin",
                Employee_Code = "EMP123",
                Salary = "50000",
                Account_Number = "1234567890",
                Account_Phone = "9876543210"

            };

            DutumPage.EnterMandatoryFields(user);
        }


        [When("Click on the Attendance menu")]
        public void WhenClickOnTheAttendanceMenu()
        {
            DutumPage.ClickAttendanceMenu();
            Thread.Sleep(5000); // Wait for 5 seconds to see the search results
        }

        [Then("the attendance page will be displayed")]
        public void ThenTheAttendancePageWillBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("attendance"), "Attendance page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("Attendance page is displayed successfully");
        }
        [When("Click on the Timesheet menu")]
        public void WhenClickOnTheTimesheetMenu()
        {
            DutumPage.ClickTimesheetMenu();
            Thread.Sleep(5000); // Wait for 5 seconds to see the search results
        }

        [Then("the timesheet page will be displayed")]
        public void ThenTheTimesheetPageWillBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("timesheet"), "Timesheet page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("Timesheet page is displayed successfully");
        }

        [When("Click on the Resource menu")]
        public void WhenClickOnTheResourceMenu()
        {
            DutumPage.ClickResourceMenu();
            Thread.Sleep(5000); // Wait for 5 seconds to see the search results
        }

        [Then("the resource page will be displayed")]
        public void ThenTheResourcePageWillBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("resource"), "Resource page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("Resource page is displayed successfully");
        }

        [When("Click on the Organisation menu")]
        public void WhenClickOnTheOrganisationMenu()
        {
            DutumPage.ClickOrganisationMenu();
            Thread.Sleep(5000); // Wait for 5 seconds to see the search results
        }
        [Then("the organisation page will be displayed")]
        public void ThenTheOrganisationPageWillBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("organization"), "Organization page is not displayed");
            Hooks.Hooks.scenario.Value!.Pass("Organization page is displayed successfully");
        }
        [When("enter the Employee name in search field in first letter as capital")]
        public void WhenEnterTheUsernameInSearchField()
        {
            DutumPage.EnterInSearchField("Jasmine");

            Thread.Sleep(3000); // Wait for 2 seconds to see the search results
            Hooks.Hooks.scenario.Value!.Pass("User clicks on the search button and enter the name ");
        }

        [Then("the searched Name with first letter as capital will be displayed in the user list")]
        public void ThenTheSearchedUserWillBeDisplayed()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserDisplayed("Jasmine"), "The searched Name with first letter as capital is not displayed");
                Console.WriteLine("The searched Name with first letter as capital is displayed successfully");
                Hooks.Hooks.scenario.Value!.Pass("The searched Name with first letter as capital is displayed successfully");
            }
            catch
            {
                Console.WriteLine("The searched name with first letter as capital is not displayed");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The searched Name with first letter as capital is not displayed", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            }

        }
        [When("enter the Employee name in search field in first letter as small")]
        public void WhenEnterTheEmployeeNameInSearchFieldInFirstLetterAsSmall()
        {
            DutumPage.EnterInSearchField("jasmine");
            Thread.Sleep(3000); // Wait for 2 seconds to see the search results
            Hooks.Hooks.scenario.Value!.Pass("User clicks on the search button and enter the name ");
        }
        [Then("the searched Name with first letter as small will be displayed in the user list")]
        public void ThenTheSearchedNameWithFirstLetterAsSmallWillBeDisplayed()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserDisplayed("jasmine"), "The searched Name with first letter as small is not displayed");
                Console.WriteLine("The searched Name with first letter as small is displayed successfully");
                Hooks.Hooks.scenario.Value!.Pass("Th e searched Name with first letter as small is displayed successfully");
            }
            catch
            {
                Console.WriteLine("The searched name with first letter as small is not displayed");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The searched Name with first letter as small is not displayed", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            }
        }
        [When("select the user role in search field")]
        public void WhenSelectTheUserRoleInSearchField()
        {
            DutumPage.EnterInSearchField("USER");
            Thread.Sleep(3000); // Wait for 2 seconds to see the search results
            Hooks.Hooks.scenario.Value!.Pass("User clicks on the search button and enter the user role ");
        }
        [Then("the searched user role will be displayed in the user list")]
        public void ThenTheSearchedUserRoleWillBeDisplayed()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserRoleDisplayed("USER"), "The searched user role is not displayed");
                Console.WriteLine("The searched user role is displayed successfully");
                Hooks.Hooks.scenario.Value!.Pass("The searched user role is displayed successfully");
            }
            catch
            {
                Console.WriteLine("The searched user role is not displayed");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The searched user role is not displayed", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }
        [When("enter the user Email in search field")]
        public void enterTheUserEmailInSearchField()
        {
            DutumPage.EnterInSearchField("admin@gmail.com");
            Thread.Sleep(3000); // Wait for 2 seconds to see the search results
            Hooks.Hooks.scenario.Value!.Pass("User clicks on the search button and enter the user Email ");
        }
        [Then("the entered user Email will be displayed in the user list")]
        public void theEnteredUserEmailWillBeDisplayedInTheUserlist()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserEmailDisplayed("admin@gmail.com"), "The searched user Email is not displayed");
                Console.WriteLine("The searched user Email is displayed successfully");
                Hooks.Hooks.scenario.Value!.Pass("The searched user Email is displayed successfully");
            }
            catch
            {
                Console.WriteLine("The searched user Email is not displayed");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The searched user Email is not displayed", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            }
        }
        [When("enter the user Mobile_Num in search field")]
        public void enterTheUserMobile_NumInSearchField()
        {
            DutumPage.EnterInSearchField("9677185680");
            Thread.Sleep(3000); // Wait for 2 seconds to see the search results
            Hooks.Hooks.scenario.Value!.Pass("User clicks on the search button and enter the user Email ");
        }
        [Then("the entered user Mobile_Num will be displayed in the user list")]
        public void theEnteredUserMobile_NumWillBeDisplayedInTheUserlist()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserMobile_NumDisplayed("admin@gmail.com"), "The searched user Mobile_Num is not displayed");
                Console.WriteLine("The searched user Mobile_Num is displayed successfully");
                Hooks.Hooks.scenario.Value!.Pass("The searched user Mobile_Num is displayed successfully");
            }
            catch
            {
                Console.WriteLine("The searched user Mobile_Num is not displayed");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The searched user Mobile_Num is not displayed", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            }
        }
        [StepDefinition("a success message should be displayed")]
        public void aSuccessMessageShouldBeDisplayed()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserSavedSuccessfullyDisplayed("Success"), "The Employee Details not Saved Successfully");
                Console.WriteLine("The Employee Details Saved Successfully");
                Hooks.Hooks.scenario.Value!.Pass("The Employee Details Saved Successfully");
            }
            catch
            {
                Console.WriteLine("The Employee Details not Saved Successfully");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The Employee Details not Saved Successfully", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }

        [StepDefinition("the employee should appear in the employee list")]
        public void theEmployeeNameShouldAppearInEmployeeList()
        {
            try
            {
                Assert.IsTrue(DutumPage.IsUserDisplayed("maha"), "The employee is not displayed in the employee list.");
                Console.WriteLine("The employee is displayed in the employee list");
                Hooks.Hooks.scenario.Value!.Pass("The employee is not displayed in the employee list.");
            }
            catch
            {
                Console.WriteLine("The employee is not displayed in the employee list.");
                string screenshotPath = ScreenshotHelper.TakeScreenshot(driver, "FinalResult");
                Hooks.Hooks.scenario.Value!.Fail("The employee is not displayed in the employee list.", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }
        [When("enter the mandatory fields with employee ID {string}")]
        public void WhenEnterTheMandatoryFieldsWithEmployeeIDEMP123(string employeeID, Reqnroll.Table table)
        {
            UserDetails user = table.CreateInstance<UserDetails>();
            user.Employee_Code = employeeID;

            DutumPage.EnterMandatoryFields(user);
        }
           
        [Then("an \"Employee ID already exists\" error message should be displayed")]

            public void EmployeeIDAlreadyExistsErrorMessageShouldBeDisplayed()
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IAlert alert = wait.Until(driver =>
                {
                    try
                    {
                        return driver.SwitchTo().Alert();
                    }

                    catch (NoAlertPresentException)
                    {
                        return null;
                    }
                });
                String alertText = alert.Text;

                Assert.That(alertText, Is.EqualTo("Employee ID already exists"));

                alert.Accept();



            }
        [When("enter the mandatory fields with email {string}")]
        public void WhenEnterTheMandatoryFieldsWithemail(string email, Reqnroll.Table table)
        {
            UserDetails user = table.CreateInstance<UserDetails>();
            user.Email = email;

            DutumPage.EnterMandatoryFields(user);
        }
        [Then("an \"Email already exists\" error message should be displayed")]

        public void EmailAlreadyExistsErrorMessageShouldBeDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(driver =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }

                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
            String alertText = alert.Text;

            Assert.That(alertText, Is.EqualTo("Email already exists"));

            alert.Accept();



        }
        [When("enter the mandatory fields with mobile number {string}")]
        public void WhenEnterTheMandatoryFieldsWithMobileNumber(string mobileNumber, Reqnroll.Table table)
        {
            UserDetails user = table.CreateInstance<UserDetails>();
            user.Mobile = mobileNumber;

            DutumPage.EnterMandatoryFields(user);
        }
        [Then("an \"Mobile number already exists\" error message should be displayed")]

        public void MobileNumberAlreadyExistsErrorMessageShouldBeDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(driver =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }

                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
            String alertText = alert.Text;

            Assert.That(alertText, Is.EqualTo("Mobile number already exists"));

            alert.Accept();


        }

    }
    }


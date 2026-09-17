using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Utilities;


namespace TestProject1.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver driver;

        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToUrl()
        {
            driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
        }
        public void NavigateToQaUrl()
        {
            driver.Navigate().GoToUrl(ConfigReader.QaURL);
        }

        public void ClickAdvancedButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement advancedButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Advanced')]")));
            advancedButton.Click();

        }

        public void ClickProceedLink()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement proceedLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Proceed to dutam.svtawny.com (unsafe)')]")));
            proceedLink.Click();

        }

        public void DutumMainPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement DutumMainPage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@class=\"logo mb-5\"]")));
            DutumMainPage.Click();
        }

        public void ClickAdminLoginButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement adminButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@src='../../../../../assets/admin.png']//following::button[text()=' Login ']")));
            adminButton.Click();
            Thread.Sleep(3000);

            Console.WriteLine(driver.Url);
            Console.WriteLine(driver.Title);


        }

        public void EnterCredential(string username, string password)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            Console.WriteLine("Current URL: " + driver.Url);

            var inputs = driver.FindElements(By.TagName("input"));

            Console.WriteLine("Total Inputs Found: " + inputs.Count);

            foreach (var input in inputs)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine(input.GetAttribute("outerHTML"));
            }

            IWebElement usernameTxt = driver.FindElement(By.XPath("//input[@placeholder='emailaddress']"));
            usernameTxt.SendKeys(username);


            IWebElement Password = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='password']")));
            Password.Clear();
            Password.SendKeys(password);
        }
        public void ClickLoginButton()
        {
            driver.FindElement(By.XPath("//button[@label='Login']")).Click();
        }
        public void ClickUserImageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userImageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@class='ng-star-inserted']")));
            userImageButton.Click();
        }
        public void ClickLogoutButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement logoutButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Logout']")));
            logoutButton.Click();
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }
        public string GetLoggedInUsername()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loggedInUser = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='viswa ']")));
            return loggedInUser.Text;

        }
        public bool ShowErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Sorry :(']")));
            return errorMessage.Displayed;
        }


        public string ClickUserButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement addUserButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='User']")));
            addUserButton.Click();
            return addUserButton.Text;
        }
        public string ClickAdd_UserButton()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement add_UserButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Add User']")));
            add_UserButton.Click();
            return add_UserButton.Text;


        }


        public string EnterMandatoryFields(UserDetails user)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement nameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name']//following::input[@formcontrolname='username']")));
            nameField.Clear();
            nameField.SendKeys(user.Name);
            IWebElement emailField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@formcontrolname='email']")));
            emailField.Clear();
            emailField.SendKeys(user.Email);
            IWebElement mobileField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@formcontrolname='phone']")));
            mobileField.Clear();
            mobileField.SendKeys(user.Mobile);
            IWebElement assignClientField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Assign Client']//following::div[@class='p-multiselect-trigger'][1]")));
            assignClientField.Click();
            IWebElement dropdown_Menu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(),'{user.Assign_Client}')]")));
            dropdown_Menu.Click();
            IWebElement Close_Button = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@aria-label='Close']")));
            Close_Button.Click();
            IWebElement genderField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Select a Gender']//following::div[@data-pc-section='trigger'][1]")));
            genderField.Click();
            IWebElement Click_Female = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(),'{user.Gender}')]")));
            Click_Female.Click();
            IWebElement assignSkillField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Select skill']//following::div[@class='p-multiselect-trigger']")));
            assignSkillField.Click();
            IWebElement Click_HICAD_Modeling = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(),'{user.Assign_Skill}')]")));
            Click_HICAD_Modeling.Click();
            IWebElement Close_button = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@aria-label='Close']")));
            Close_button.Click();
            IWebElement accountNameField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@formcontrolname='accountName']")));
            accountNameField.Clear();
            accountNameField.SendKeys(user.Account_Name);
            IWebElement accountEmailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@formcontrolname='accountEmail']")));
            accountEmailField.Clear();
            accountEmailField.SendKeys(user.Account_Email);
            IWebElement selectDesignationField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Designation']//following::span[text()='Select Designation']//following::div[@class='p-dropdown-trigger'][1]")));
            selectDesignationField.Click();
            IWebElement click_Jnr_Project_Eng = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(),'{user.Designation}')]")));
            click_Jnr_Project_Eng.Click();
            IWebElement joined_DateField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@aria-controls='pn_id_32_panel']")));
            joined_DateField.Click();

            IWebElement Join_Date_SelectField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[normalize-space(text())='{user.Joined_Date}']//ancestor::td")));
            Join_Date_SelectField.Click();

            IWebElement reporting_toField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Select a User']//following::div[@class='p-dropdown-trigger'][1]")));
            reporting_toField.Click();
            // Click Reporting To dropdown
            IWebElement reportingToDropdown = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//label[normalize-space()='Reporting To']/following::div[contains(@class,'p-dropdown')][1]")
                ));

            reportingToDropdown.Click();

            // Select Reporting To value
            IWebElement super_Admin = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath($"//li[@role='option' and @aria-label='{user.Reporting_To}']")
                ));

            super_Admin.Click();
            IWebElement roleField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Select a role']//following::div[@aria-label='dropdown trigger']")));
            roleField.Click();
            IWebElement role_IT_Admin = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//li[@role='option'])[1]")));
            role_IT_Admin.Click();
            IWebElement emp_codeField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@formcontrolname='empcode']")));
            emp_codeField.Clear();
            emp_codeField.SendKeys(user.Employee_Code);
            IWebElement salaryField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@formcontrolname='salary']")));
            salaryField.Clear();
            salaryField.SendKeys(user.Salary);
            IWebElement account_NumberField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@formcontrolname='accountNumber']")));
            account_NumberField.Clear();
            account_NumberField.SendKeys(user.Account_Number);
            IWebElement account_PhoneField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@formcontrolname='accountPhoneNo']")));
            account_PhoneField.Clear();
            account_PhoneField.SendKeys(user.Account_Phone);


            return "Mandatory fields entered successfully";

        }

        public string ClickSaveButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement saveButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Save']")));
            saveButton.Click();
            return "User saved successfully";
        }

        public string ClickAttendanceMenu()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement attendanceMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Attendance']")));
            actions.MoveToElement(attendanceMenu).Click().Perform();

            return "Attendance menu clicked successfully";
        }

        public string ClickTimesheetMenu()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement timesheetMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Timesheet']")));
            actions.MoveToElement(timesheetMenu).Click().Perform();

            return "Timesheet menu clicked successfully";
        }

        public string ClickResourceMenu()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement resourceMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Resource']")));
            actions.MoveToElement(resourceMenu).Click().Perform();

            return "Resource menu clicked successfully";
        }

        public string ClickOrganisationMenu()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement organisationMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Organization']")));
            actions.MoveToElement(organisationMenu).Click().Perform();

            return "Organisation menu clicked successfully";
        }

        public string EnterInSearchField(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Search']")));
            searchField.Clear();
            searchField.SendKeys(name);
            return "Username entered in search field successfully";
        }

        public bool IsUserDisplayed(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(translate(text(),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'),'{name.ToLower()}')]")));
            return userElement.Displayed;
        }

        public bool IsUserRoleDisplayed(string UserRole)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userRoleElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[contains(text(),'{UserRole}')]")));
            return userRoleElement.Displayed;
        }
        public bool IsUserEmailDisplayed(string UserEmail)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement UserEmailElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[contains(text(),'{UserEmail}')]")));
            return UserEmailElement.Displayed;

        }
        public bool IsUserMobile_NumDisplayed(string UserMobile_Num)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement UserMobile_NumElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[contains(text(),'{UserMobile_Num}')]")));
            return UserMobile_NumElement.Displayed;

        }

        public bool IsUserSavedSuccessfullyDisplayed(string expectedMessage)
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

            String actualMessage = alert.Text;

            Console.WriteLine("Actual Message: " + actualMessage);

            bool isMessageCorrect = actualMessage.Contains(expectedMessage);

            alert.Accept(); // Accept the alert to close it

            return isMessageCorrect;

        }

        public string emailErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement emailErrorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Error: heerayatha@gmail.com email already taken')]")));
            return emailErrorMessage.Text;

        }
    }
}

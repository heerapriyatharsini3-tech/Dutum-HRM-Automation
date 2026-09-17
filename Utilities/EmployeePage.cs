using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProject1;

namespace TestProject1.Utilities
{
    public class EmployeePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Actions actions;

        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver;
            // initialize wait and actions here
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.actions = new Actions(driver);
        }

        public void openEmployeePage()
        {
            driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            driver.Manage().Window.Maximize();

            Thread.Sleep(3000);

            // opening the advanced button and proceeding to the dutum site
            // use the field 'wait' initialized in the constructor
            IWebElement Advanced_Button = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Advanced')]")));
            Advanced_Button.Click();

            IWebElement proceed_to_Dutum = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Proceed to dutam.svtawny.com (unsafe)')]")));
            proceed_to_Dutum.Click();

            IWebElement admin_Login_Buttton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Admin']//following::button[text()=' Login ']")));
            admin_Login_Buttton.Click();

            IWebElement emailaddress_Buttton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='emailaddress']")));
            emailaddress_Buttton.SendKeys("viswa.s@tawnytech.in");

            IWebElement password_Buttton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='password']")));
            password_Buttton.SendKeys("VJviswa@107");

            IWebElement login_Buttton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Login']")));
            login_Buttton.Click();

            if (login_Buttton.Displayed)
            {
                Console.WriteLine("Login successful. Dashboard is displayed.");
            }
            else
            {
                Console.WriteLine("Login failed. Dashboard is not displayed.");
            }

            Thread.Sleep(3000);

            // use the field 'actions'
            IWebElement User = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Home']//following::span[text()='User'][1]")));
            actions.MoveToElement(User).Perform();

            Console.WriteLine("Cursor moved to User button");

            IWebElement User_Click = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='User']")));
            User_Click.Click();
        }

        // moved method out of openEmployeePage, fixed visibility and return type
        public List<Employee> GetTheEmployeesDetails()
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                // Wait for table
                IWebElement table = wait.Until(
                    ExpectedConditions.ElementIsVisible(
                        By.XPath("//table[@role='table']")
                    )
                );

                // Get rows from current page
                IList<IWebElement> rows =
                    table.FindElements(By.XPath(".//tbody/tr"));

                Console.WriteLine("====================================");
                Console.WriteLine("Reading current page");
                Console.WriteLine("Rows found: " + rows.Count);
                Console.WriteLine("====================================");

                // Read ALL employees from current page
                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells =
                        row.FindElements(By.XPath(".//td"));

                    // Skip invalid/header/unexpected rows
                    if (cells.Count < 16)
                        continue;

                    Employee employee = new Employee();

                    employee.Name = cells[0].Text;
                    employee.Emp_code = cells[1].Text;
                    employee.Skills = cells[2].Text;
                    employee.Joined_date = cells[3].Text;
                    employee.Role = cells[4].Text;
                    employee.Assigned_Client = cells[5].Text;
                    employee.Email = cells[6].Text;
                    employee.Mobile = cells[7].Text;
                    employee.Account_Name = cells[8].Text;
                    employee.Account_No = cells[9].Text;
                    employee.Account_Email = cells[10].Text;
                    employee.Salary = cells[11].Text;
                    employee.Reporting = cells[12].Text;
                    employee.Onboard_Mail = cells[13].Text;
                    employee.State = cells[14].Text;
                    employee.Action = cells[15].Text;

                    employees.Add(employee);

                    Console.WriteLine(
                        $"Employee added: {employee.Name}, " +
                        $"{employee.Emp_code}, " +
                        $"{employee.Skills}, " +
                        $"{employee.Joined_date}, " +
                        $"{employee.Role}, " +
                        $"{employee.Assigned_Client}, " +
                        $"{employee.Email}, " +
                        $"{employee.Mobile}, " +
                        $"{employee.Account_Name}, " +
                        $"{employee.Account_No}, " +
                        $"{employee.Account_Email}, " +
                        $"{employee.Salary}, " +
                        $"{employee.Reporting}, " +
                        $"{employee.Onboard_Mail}, " +
                        $"{employee.State}, " +
                        $"{employee.Action}"
                    );
                }

                // =========================================
                // PAGINATION - AFTER READING ENTIRE PAGE
                // =========================================

                // Find Next button
                IWebElement nextButton = wait.Until(
                    ExpectedConditions.ElementExists(
                        By.XPath("//button[@aria-label='Next Page']")
                    )
                );

                // Check whether Next button is disabled
                string? disabled = nextButton.GetAttribute("disabled");
                string? ariaDisabled = nextButton.GetAttribute("aria-disabled");

                if (disabled != null || ariaDisabled == "true")
                {
                    Console.WriteLine("Last page reached.");
                    break;
                }

                // Get first employee name from current page
                string oldFirstEmployee = "";

                IList<IWebElement> currentRows =
                    table.FindElements(By.XPath(".//tbody/tr"));

                foreach (IWebElement currentRow in currentRows)
                {
                    IList<IWebElement> currentCells =
                        currentRow.FindElements(By.XPath(".//td"));

                    if (currentCells.Count >= 16)
                    {
                        oldFirstEmployee = currentCells[0].Text;
                        break;
                    }
                }

                Console.WriteLine(
                    "Current first employee: " + oldFirstEmployee
                );

                // Click Next
                nextButton.Click();

                Console.WriteLine("Moving to next page...");

                // Wait until first employee changes
                wait.Until(driver =>
                {
                    try
                    {
                        IWebElement newTable =
                            driver.FindElement(
                                By.XPath("//table[@role='table']")
                            );

                        IList<IWebElement> newRows =
                            newTable.FindElements(
                                By.XPath(".//tbody/tr")
                            );

                        foreach (IWebElement newRow in newRows)
                        {
                            IList<IWebElement> newCells =
                                newRow.FindElements(By.XPath(".//td"));

                            if (newCells.Count >= 16)
                            {
                                string newFirstEmployee =
                                    newCells[0].Text;

                                return newFirstEmployee != oldFirstEmployee;
                            }
                        }

                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return true;
                    }
                });

                Console.WriteLine("Next page loaded successfully.");
            }

            Console.WriteLine("====================================");
            Console.WriteLine(
                "TOTAL EMPLOYEES COLLECTED: " + employees.Count
            );
            Console.WriteLine("====================================");

            return employees;
        }
    }
}

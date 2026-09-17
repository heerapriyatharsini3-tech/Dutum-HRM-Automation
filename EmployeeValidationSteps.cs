using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestProject1.Drivers;
using TestProject1.Pages;
using TestProject1.TestData;
using TestProject1.Utilities;

namespace TestProject1
{
    [Binding]
    public class EmployeeValidationSteps
    {
        private IWebDriver driver;
        private EmployeePage employeePage;
        private List<Employee> employees = new List<Employee>();
        private EmployeeValidator employeeValidator;



        public EmployeeValidationSteps()
        {
          ;
           employeeValidator = new EmployeeValidator();

        }
        [Given("I am on the Employee page")]
        public void GivenTheUserIsOnTheEmployeePage()
        {
            driver = DriverFactory.GetDriver();
           
            employeePage = new EmployeePage(driver);

            Console.WriteLine("User is on Employee page.");

        }
        [When("I Read all employee details")]
        public void WhenIReadAllEmployeeDetails()
        {
            employees = employeePage.GetTheEmployeesDetails();
        }
        [Then("Employee details should be displayed on the Excel sheet")]
        public void ThenEmployeeDetailsShouldBeDisplayedOnTheExcelSheet()
        {
            // Implementation for checking employee details on Excel sheet
            Assert.That(employees, Is.Not.Null);
            Assert.That(employees.Count, Is.GreaterThan(0));

            EmployeeData employeeData = new EmployeeData();

            employeeData.WriteEmployeeDataToExcel(employees);

           

            Console.WriteLine(
                "Employee details successfully written to Excel."
            );


        }
        [Then("Employee ID should not be duplicated")]
        public void ThenEmployeeIdShouldNotBeDuplicated()
        {
            var duplicateIds = employeeValidator.GetDuplicateEmployeeCodes(employees);

            if (duplicateIds.Any())
            {
                string duplicateIdMessage =
                    "Duplicate Employee ID found: " +
                    string.Join(", ", duplicateIds);

                Assert.Fail(duplicateIdMessage);
            }

            Assert.Pass("No duplicate Employee ID found.");
        }
        [Then("Employee Email should not be duplicated")]
        public void ThenEmployeeEmailShouldNotBeDuplicated()
        {
            var duplicateEmails = employeeValidator.GetDuplicateEmployeeEmails(employees);
            if (duplicateEmails.Any())
            {
                string duplicateEmailMessage =
                    "Duplicate Employee Email found: " +
                    string.Join(", ", duplicateEmails);
                Assert.Fail(duplicateEmailMessage);
            }
            Assert.Pass("No duplicate Employee Email found.");

        }
        [Then("Employee Mobile Number should not be duplicated")]
        public void ThenEmployeeMobileNumberShouldNotBeDuplicated()
        {
            var duplicateMobileNumbers = employeeValidator.GetDuplicateEmployeeMobileNumbers(employees);
            if (duplicateMobileNumbers.Any())
            {
                string duplicateMobileNumberMessage =
                    "Duplicate Employee Mobile Number found: " +
                    string.Join(", ", duplicateMobileNumbers);
                Assert.Fail(duplicateMobileNumberMessage);
            }
            Assert.Pass("No duplicate Employee Mobile Number found.");
        }
        [Then("Employee ID should not be null")]
        public void ThenEmployeeIdShouldNotBeNull()
        {
            var nullIds = employees.Where(e => string.IsNullOrEmpty(e.Emp_code)).ToList();
            if (nullIds.Any())
            {
                Assert.Fail("Employee ID should not be null.");
            }
            Assert.Pass("Employee ID is not null.");
        }
        [Then("Employee Name should not be null")]
        public void ThenEmployeeNameShouldNotBeNull()
        {
            var nullNames = employees.Where(e => string.IsNullOrEmpty(e.Name)).ToList();
            if (nullNames.Any())
            {
                Assert.Fail("Employee Name should not be null.");
            }
            Assert.Pass("Employee Name is not null.");
        }
        [Then("Employee Department should not be null")]
        public void ThenEmployeeDepartmentShouldNotBeNull()
        {
            var nullDepartments = employeeValidator.GetEmployeesWithNullDepartment(employees);
            if (nullDepartments.Any())
            {
                Assert.Fail("Employee Department should not be null.");
            }
            Assert.Pass("Employee Department is not null.");
        }
        [Then("Employee Designation should not be null")]
        public void ThenEmployeeDesignationShouldNotBeNull()
        {
            var nullDesignations = employeeValidator.GetEmployeesWithNullDesignation(employees);
            if (nullDesignations.Any())
            {
                Assert.Fail("Employee Designation should not be null.");
            }
            Assert.Pass("Employee Designation is not null.");
        }
        [Then("Employee Email should have valid format")]
        public void ThenEmployeeEmailShouldHaveValidFormat()
        {
            var invalidEmails = employeeValidator.GetEmployeesWithInvalidEmailFormat(employees);
            if (invalidEmails.Any())
            {
                Assert.Fail("Employee Email should have a valid format.");
            }
            Assert.Pass("All Employee Emails have valid format.");
        }
    }
}

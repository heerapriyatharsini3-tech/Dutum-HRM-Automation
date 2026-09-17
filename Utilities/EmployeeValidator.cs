using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestProject1.Utilities
{
    public class EmployeeValidator
    {
        // Check duplicate Employee ID
        public IEnumerable<string> GetDuplicateEmployeeCodes(List<Employee> employees)
        {
            var duplicateEmployeeCodes = employees
                .GroupBy(e => e.Emp_code)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            return duplicateEmployeeCodes;
        }

        // Check duplicate Employee Email
        public IEnumerable<string> GetDuplicateEmployeeEmails(List<Employee> employees)
        {
            var duplicateEmployeeEmails = employees
                .GroupBy(e => e.Email)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            return duplicateEmployeeEmails;
        }
        
        // Check duplicate Employee Mobile Number
        public IEnumerable<string> GetDuplicateEmployeeMobileNumbers(List<Employee> employees)
        {
            var duplicateEmployeeMobileNumbers = employees
                .GroupBy(e => e.Mobile)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            return duplicateEmployeeMobileNumbers;
        }

        // Employee ID should not be null
        public IEnumerable<Employee> GetEmployeesWithNullEmployeeCode(List<Employee> employees)
        {
            var employeesWithNullEmployeeCode = employees
                .Where(e => string.IsNullOrEmpty(e.Emp_code))
                .ToList();
            return employeesWithNullEmployeeCode;
        }

        // Employee Name should not be null

        public IEnumerable<Employee> GetEmployeesWithNullName(List<Employee> employees)
        {
            var employeesWithNullName = employees
                .Where(e => string.IsNullOrEmpty(e.Name))
                .ToList();
            return employeesWithNullName;


        }

        //Employee Department should not be null
        public IEnumerable<Employee> GetEmployeesWithNullDepartment(List<Employee> employees)
        {
            var employeesWithNullDepartment = employees
                .Where(e => string.IsNullOrEmpty(e.Role))
                .ToList();
            return employeesWithNullDepartment;
        }
        // Employee Designation should not be null
        public IEnumerable<Employee> GetEmployeesWithNullDesignation(List<Employee> employees)
        {
            var employeesWithNullDesignation = employees
                .Where(e => string.IsNullOrEmpty(e.Assigned_Client))
                .ToList();
            return employeesWithNullDesignation;
        }

        // Employee Email should have valid format

        public IEnumerable<Employee> GetEmployeesWithInvalidEmailFormat(List<Employee> employees)
        {
            var employeesWithInvalidEmailFormat = employees
                .Where(e => !string.IsNullOrEmpty(e.Email) && !IsValidEmail(e.Email))
                .ToList();
            return employeesWithInvalidEmailFormat;
        }                               

        // Simple email validation helper to fix CS0103
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        // Check duplicate complete employee details
        public bool HasDuplicateEmployeeDetails(List<Employee> employees)
        {
            var duplicateEmployees = employees
                .GroupBy(e => new
                {
                    e.Name,
                    e.Emp_code,
                    e.Skills,
                    e.Joined_date,
                    e.Role,
                    e.Assigned_Client,
                    e.Email,
                    e.Mobile,
                    e.Account_Name,
                    e.Account_No,
                    e.Account_Email,
                    e.Salary,
                    e.Reporting,
                    e.Onboard_Mail,
                    e.State,
                    e.Action
                })
                .Where(g => g.Count() > 1)
                .ToList();

            if (duplicateEmployees.Count > 0)
            {
                Console.WriteLine("Duplicate employee details found.");

                return true;
            }

            Console.WriteLine("No duplicate employee details found.");

            return false;
        }
    }
}
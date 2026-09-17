using ClosedXML.Excel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TestProject1;

namespace TestProject1.TestData
{
    public class EmployeeData
    {
        public void WriteEmployeeDataToExcel(List<Employee> employees)
        {
            string reportpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel Report", "TestData");

            Directory.CreateDirectory(reportpath);
            string filePath = Path.Combine(reportpath, "EmployeeDetails.xlsx");

            Console.WriteLine("Number of employees received: " + employees.Count);


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                worksheet.Cell(1, 1).Value = "Name";
                worksheet.Cell(1, 2).Value = "Emp_code";
                worksheet.Cell(1, 3).Value = "Skills";
                worksheet.Cell(1, 4).Value = "Joined_Date";
                worksheet.Cell(1, 5).Value = "Role";
                worksheet.Cell(1, 6).Value = "Assigned Clients";
                worksheet.Cell(1, 7).Value = "Email";
                worksheet.Cell(1, 8).Value = "Mobile";
                worksheet.Cell(1, 9).Value = "Account_Name";
                worksheet.Cell(1, 10).Value = "Account_No";
                worksheet.Cell(1, 11).Value = "Account_Email";
                worksheet.Cell(1, 12).Value = "Salary";
                worksheet.Cell(1, 13).Value = "Reporting";
                worksheet.Cell(1, 14).Value = "Onboard_Mail";
                worksheet.Cell(1, 15).Value = "State";
                worksheet.Cell(1, 16).Value = "Action";

                int row = 2;
                foreach (var employee in employees)
                {
                    worksheet.Cell(row, 1).Value = employee.Name;
                    worksheet.Cell(row, 2).Value = employee.Emp_code;
                    worksheet.Cell(row, 3).Value = employee.Skills;
                    worksheet.Cell(row, 4).Value = employee.Joined_date;
                    worksheet.Cell(row, 5).Value = employee.Role;
                    worksheet.Cell(row, 6).Value = employee.Assigned_Client;
                    worksheet.Cell(row, 7).Value = employee.Email;
                    worksheet.Cell(row, 8).Value = employee.Mobile;
                    worksheet.Cell(row, 9).Value = employee.Account_Name;
                    worksheet.Cell(row, 10).Value = employee.Account_No;
                    worksheet.Cell(row, 11).Value = employee.Account_Email;
                    worksheet.Cell(row, 12).Value = employee.Salary;
                    worksheet.Cell(row, 13).Value = employee.Reporting;
                    worksheet.Cell(row, 14).Value = employee.Onboard_Mail;
                    worksheet.Cell(row, 15).Value = employee.State;
                    worksheet.Cell(row, 16).Value = employee.Action;
                    
                    Console.WriteLine($"Writing row {row}: {employee.Name}, {employee.Emp_code}, {employee.Skills}, {employee.Joined_date}," +
                        $" {employee.Role}, {employee.Assigned_Client}, {employee.Email}, {employee.Mobile}, {employee.Account_Name}, {employee.Account_No}," +
                        $" {employee.Account_Email}, " +
                        $"{employee.Salary}, {employee.Reporting}, {employee.Onboard_Mail}," +
                        $" {employee.State}, {employee.Action}");

                    row++;
                }

                // Make Excel readable
                worksheet.Columns().AdjustToContents();

                // Save Excel

                workbook.SaveAs(filePath);

                Console.WriteLine("====================================");
                Console.WriteLine("EXCEL REPORT CREATED");
                Console.WriteLine("Location: " + filePath);
                Console.WriteLine("====================================");
            }
            Console.WriteLine("Employee data written to Excel successfully.");
        }
    }
}

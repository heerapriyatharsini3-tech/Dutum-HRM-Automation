using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestProject1.Reports
{
    public static class ExcelReportGenerator
    {
        
        private static readonly object _lock = new object();
       
        private static readonly string ExcelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QA_Dutum_Excel_Report.xlsx");
       
        public static void UpdateTestCase(TestExecutionData data)
        {
            lock (_lock)
            {
                try
                {
                    string? directory = Path.GetDirectoryName(ExcelPath);
                    if (!string.IsNullOrEmpty(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                        if (!File.Exists(ExcelPath)) {
                    throw new FileNotFoundException($"Excel report file not found at path: {ExcelPath}");
                }
                
                
                    IWorkbook workbook;

                    ICellStyle passStyle;
                    ICellStyle failStyle;
                    ICellStyle skipStyle;

                    using (FileStream input = new FileStream(
                        ExcelPath,
                        FileMode.Open,
                        FileAccess.Read))
                    {
                        workbook = new XSSFWorkbook(input);

                        // Style for Passed
                        passStyle = workbook.CreateCellStyle();
                        passStyle.FillForegroundColor = IndexedColors.LightGreen.Index;
                        passStyle.FillPattern = FillPattern.SolidForeground;

                        IFont passFont = workbook.CreateFont();
                        passFont.IsBold = true;
                        passStyle.SetFont(passFont);

                        // Style for Failed
                        failStyle = workbook.CreateCellStyle();
                        failStyle.FillForegroundColor = IndexedColors.Red.Index;
                        failStyle.FillPattern = FillPattern.SolidForeground;

                        IFont failFont = workbook.CreateFont();
                        failFont.IsBold = true;
                        failStyle.SetFont(failFont);

                       
                        // Style for Skipped
                        skipStyle = workbook.CreateCellStyle();
                        skipStyle.FillForegroundColor = IndexedColors.Yellow.Index;
                        skipStyle.FillPattern = FillPattern.SolidForeground;

                        IFont skipFont = workbook.CreateFont();
                        skipFont.IsBold = true;
                        skipStyle.SetFont(skipFont);
                    }
                    ISheet sheet = workbook.GetSheet("Test Case Tracker"); // Assuming the first sheet is where you want to update the data
                    if (sheet == null) {
                        throw new Exception(ExcelPath + " does not contain a sheet named 'Test Case Tracker'");
                    }

                //Find testcase row
               int rowNumber = FindTestCaseRow(sheet, data.TestCaseId);

                //if testcase does not exist add a new row
                if(rowNumber == -1)
                    {
                        rowNumber = sheet.LastRowNum + 1;
                    }
                    IRow row = sheet.GetRow(rowNumber)
                                 ?? sheet.CreateRow(rowNumber);

                    SetCell(row, 0, rowNumber);
                    SetCell(row, 1, data.TestCaseId);
                    SetCell(row, 2, data.Module);
                    SetCell(row, 3, data.Scenario);
                    SetCell(row, 4, data.Priority);
                    ICell statusCell = row.GetCell(5) ?? row.CreateCell(5);
                    statusCell.SetCellValue(data.Status);
                    if (data.Status.Equals("Passed", StringComparison.OrdinalIgnoreCase))
                    {
                        statusCell.CellStyle = passStyle;
                    }
                    else if (data.Status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        statusCell.CellStyle = failStyle;
                    }
                    else if (data.Status.Equals("Skipped", StringComparison.OrdinalIgnoreCase))
                    {
                        statusCell.CellStyle = skipStyle;
                    }
                    SetCell(row, 6,
                        data.ExecutionDate.ToString(
                            "dd/MM/yyyy HH:mm:ss"));
                    SetCell(row, 7,
                        data.DurationSeconds.ToString("0.00"));
                    SetCell(row, 8, data.ErrorMessage);
                    ICell screenshotCell = row.GetCell(9) ?? row.CreateCell(9);
                    screenshotCell.SetCellValue("View Screenshot");

                    ICreationHelper helper = workbook.GetCreationHelper();

                    IHyperlink link = helper.CreateHyperlink(HyperlinkType.File);
                    link.Address = data.ScreenshotPath;

                    screenshotCell.Hyperlink = link;
                    SetCell(row, 10, data.Feature);

                    // Save workbook
                    using (FileStream output = new FileStream(
                     ExcelPath,
                     FileMode.Create,
                     FileAccess.Write))
                    {
                        workbook.Write(output);
                    }

                    workbook.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Excel report update failed: {ex.Message}");
                }
            }
        }

        private static int FindTestCaseRow(
            ISheet sheet,
            string testCaseId)
        {
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow? row = sheet.GetRow(i);

                if (row == null)
                    continue;

                string existingId =
                    row.GetCell(1)?.ToString()?.Trim() ?? "";

                if (existingId.Equals(
                        testCaseId,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        private static void SetCell(
            IRow row,
            int columnIndex,
            object value)
        {
            ICell cell =
                row.GetCell(columnIndex)
                ?? row.CreateCell(columnIndex);

            cell.SetCellValue(
                value?.ToString() ?? string.Empty);
        }
    }
}

                
        
    


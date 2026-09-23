using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Reports
{
    public class TestExecutionData
    {
        public string TestCaseId { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string Scenario { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ExecutionDate { get; set; }
        public double DurationSeconds { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string ScreenshotPath { get; set; } = string.Empty;
        public string Feature { get; set; } = string.Empty;
    }
}

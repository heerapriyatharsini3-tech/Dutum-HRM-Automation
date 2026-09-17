using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using TestProject1.Drivers;
using TestProject1.Reports;
using static Reqnroll.Analytics.ReqnrollFeatureUseEvent;

namespace TestProject1.Hooks
{
    [Binding]
    public class Hooks
    {
        public static ExtentReports? extent;

        // Stores feature report nodes safely for parallel execution
        private static readonly ConcurrentDictionary<string, ExtentTest>
            featureNodes = new();

        // Stores scenario report node for the current execution context
        public static AsyncLocal<ExtentTest?> scenario =
            new AsyncLocal<ExtentTest?>();

        private static readonly object reportLock = new object();



        [BeforeTestRun]
        public static void StartReport()
        {
            extent = ExtentManager.GetInstance();
        }

       

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            DriverFactory.InitDriver();
            // scenario.Value = feature.Value!.CreateNode(scenarioContext.ScenarioInfo.Title);

            // 2. Get feature name
            string featureName =
                featureContext
                    .FeatureInfo
                    .Title;
            
        
        // 3. Get or create the feature node
        ExtentTest featureTest =
            featureNodes.GetOrAdd(
                featureName,
                name =>
                {
                    lock (reportLock)
                    {
                        return extent!.CreateTest(name);
                    }
                });
            // 4. Create scenario node
            lock (reportLock)
            {
                scenario.Value =
                    featureTest.CreateNode(
                        scenarioContext.ScenarioInfo.Title);
            }

            Console.WriteLine(
                $"Scenario started: {scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            string filepath = "";
            try
            {
                if (scenario.Value == null)
                {
                    Console.WriteLine(
                        "Warning: Extent scenario node was not created.");
                }
                else
                {
                    if (scenarioContext.TestError == null)
                    {
                        scenario.Value!.Pass("Scenario Passed");
                    }
                    else
                    {
                        try
                        {
                            // Capture screenshot on failure

                            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                            Directory.CreateDirectory(folderpath);

                            // Unique screenshot name

                            string filename = "ErrorScreenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + Guid.NewGuid().ToString("N").Substring(0, 6) + ".png";
                            filepath = Path.Combine(folderpath, filename);

                            // Get current scenario's driver
                            IWebDriver driver = DriverFactory.GetDriver();

                            // Take screenshot
                            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                            screenshot.SaveAsFile(filepath);

                            // Attach screenshot to the report
                            scenario.Value!.Fail(scenarioContext.TestError.Message).AddScreenCaptureFromPath(filepath);
                        }
                        catch (Exception screenshotException)
                        {
                            scenario.Value!.Fail(scenarioContext.TestError.Message + " (Screenshot capture failed: " + screenshotException.Message + ")");
                        }
                    }
                }

                // =========================================
                // GET TAG VALUES
                // =========================================
                string testCaseId = scenarioContext.ScenarioInfo.Tags
                    .FirstOrDefault(t => t.StartsWith("TC_"))
                    ?? Guid.NewGuid().ToString();

                string module = scenarioContext.ScenarioInfo.Tags
                    .FirstOrDefault(t => t.StartsWith("Module_")) ?? "";

                string priority = scenarioContext.ScenarioInfo.Tags
                    .FirstOrDefault(t => t.StartsWith("Priority_")) ?? "";

                // =========================================
                // TEST EXECUTION DATA
                // =========================================

                TestExecutionData data = new TestExecutionData
                {
                    TestCaseId = testCaseId,
                    Module = module,
                    Scenario = scenarioContext.ScenarioInfo.Title,
                    Priority = priority,
                    Status = scenarioContext.TestError == null ? "Passed" : "Failed",
                    ExecutionDate = DateTime.Now,
                    DurationSeconds = 0,
                    ErrorMessage = scenarioContext.TestError?.Message ?? "",
                    ScreenshotPath = filepath,
                    Feature = "Login"
                };
                Console.WriteLine("Calling ExcelReportGenerator...");
                ExcelReportGenerator.UpdateTestCase(data);
                Console.WriteLine("ExcelReportGenerator completed.");
            }
            finally
            {
                DriverFactory.QuitDriver();
            }
        }

        [AfterTestRun]
        public static void EndReport()
        {
            extent?.Flush();
        }
    }
}

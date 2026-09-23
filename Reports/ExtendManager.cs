using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject1.Reports
{
    public class ExtentManager
    {
        private static ExtentReports? extent;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                //var htmlReporter = new ExtentSparkReporter("ExtentReport.html");
                String reportPath1 = Path.Combine(Directory.GetCurrentDirectory(),"Reports", "ExtentReport_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
                String reportPath2 = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "ExtentSpark.html");
               
                
                var sparkReporter1 = new ExtentSparkReporter(reportPath1);
                var sparkReporter2 = new ExtentSparkReporter(reportPath2);

                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter1);
                extent.AttachReporter(sparkReporter2);
            }

            return extent;
        }
    }
}
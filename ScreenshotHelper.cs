using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestProject1
{
    internal class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName =$"{screenshotName}_" + 
                $"{DateTime.Now:yyyyMMdd_HHmmss_fff}_"+
                $"{Guid.NewGuid().ToString("N").Substring(0, 6)}.png";

            string filePath = Path.Combine(folderPath, fileName);
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);
            return filePath;
        }
    }
}

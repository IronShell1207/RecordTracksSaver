using System;
using System.Globalization;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RecordGetTracks
{
    class SeleniumHelper
    {
        private static IWebDriver _driver;
        public static void ResetDriver()
        {
            try
            {
                if (_driver != null)
                {
                    ChromeDriver.Close();
                    ChromeDriver.Quit();
                    _driver = null;
                }
            }
            catch (Exception ex) { }
        }
        public static IWebDriver ChromeDriver
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }
                var chromeDriverService = ChromeDriverService.CreateDefaultService(@"C:\Users\unkno\AppData\Local\Google\Chrome\Application\");
                chromeDriverService.HideCommandPromptWindow = true;
                var chromeOptions = new ChromeOptions();
                _driver = new ChromeDriver(chromeDriverService, chromeOptions);
                // Avoid synchronization issues by applying timed delay to each step if necessary
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                return _driver;
            }
        }
        public static void AfterTestRun()
        {
            ResetDriver();
        }


        public static void Wait(int miliseconds, int maxTimeOutSeconds = 60)
        {
            var wait = new WebDriverWait(ChromeDriver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }



        public static string GetCosasBuildVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var result = String.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.MinorRevision);

            return result;
        }
    }
}

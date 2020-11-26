using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RecordGetTracks
{
    class SeleniumHelper
    {
        private static IWebDriver _driver;
        public static void QuitDriver()
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
        public static void ClickLink(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(d => d.FindElement(by)); //ждем пока объект заспавнится 
                _driver.FindElement(by).Click();
            }
            catch (NoSuchElementException ex)
            { // если не прогрузился

            }
        }
        public static bool SendKeys(By by, string[] text) // печатаем текст в поле безошибочно
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(d => d.FindElement(by));
                foreach (string str in text)
                {
                    _driver.FindElement(by).SendKeys(str);
                    Thread.Sleep(50);
                }
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }
        public static IWebDriver ChromeDriver
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }
                var chromeDriverService = ChromeDriverService.CreateDefaultService(SettingsStatic.settings.ChromePath);  // сделать возможность менять
                chromeDriverService.HideCommandPromptWindow = true;
                var chromeOptions = new ChromeOptions(); 
                _driver = new ChromeDriver(chromeDriverService, chromeOptions);
                // Avoid synchronization issues by applying timed delay to each step if necessary
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
              //  _driver.Manage().Window.Minimize();
                return _driver;
            }
            set
            {
                _driver = value;
            }
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

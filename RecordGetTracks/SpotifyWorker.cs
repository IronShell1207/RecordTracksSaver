using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpotifyData;

namespace RecordGetTracks
{
    class SpotifyWorker
    {
        public static void AuthSpoti(string usrName, string usrPass)
        {
            SeleniumHelper.ChromeDriver.Navigate().GoToUrl(SpotifyPages.MainPageUrl); // переходим на страницу spotify
            ClickLink(SpotifyPatches.loginPageButton); // клик на ссылку Log in
            if (SeleniumHelper.ChromeDriver.Url != SpotifyPages.MainPageUrl)
            {
                SendKeys(SpotifyPatches.LoginField, new[] { usrName });
                SendKeys(SpotifyPatches.PassField, new[] { usrPass });
                ClickLink(SpotifyPatches.LogInButt);
            }
        }
        private static void ClickLink(By by)
        {
            var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(d => d.FindElement(by)); //ждем пока объект заспавнится 
                SeleniumHelper.ChromeDriver.FindElement(by).Click();
            }
            catch (NoSuchElementException ex)
            { // если не прогрузился

            }
        }
        private static bool SendKeys(By by, string[] text) // печатаем текст в поле безошибочно
        {
            var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(d => d.FindElement(by));
                foreach (string str in text)
                {
                    SeleniumHelper.ChromeDriver.FindElement(by).SendKeys(str);
                    Thread.Sleep(50);
                }
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }
    }
}

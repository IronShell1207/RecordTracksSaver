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
            SeleniumHelper.ClickLink(SpotifyPatches.loginPageButton); // клик на ссылку Log in
            if (SeleniumHelper.ChromeDriver.Url != SpotifyPages.MainPageUrl)
            {
                SeleniumHelper.SendKeys(SpotifyPatches.LoginField, new[] { usrName });
                SeleniumHelper.SendKeys(SpotifyPatches.PassField, new[] { usrPass });
                SeleniumHelper.ClickLink(SpotifyPatches.LogInButt);
            }
        }
       
    }
}

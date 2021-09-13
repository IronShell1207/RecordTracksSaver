using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ChromeDriverDownloader
{
    class Links
    {
        public static string chromeLinkAdder = "https://chromedriver.storage.googleapis.com/";
        public static string VersionsLink = "https://chromedriver.storage.googleapis.com/index.html?path=&sort=desc";
        public static string ChromeDriversApiXMLLink = "https://chromedriver.storage.googleapis.com/";
        public static Regex VersionRE = new Regex(@"(?<ver>(?<rootver>[0-9]*)\.[0-9]*\.[0-9]*\.[0-9]*)/chromedriver_win32.zip");
        public static Regex LastVe = new Regex(@"LATEST_RELEASE_[0-9.]*");
    }
}

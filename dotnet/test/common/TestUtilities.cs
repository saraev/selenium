using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenQA.Selenium
{
    public class TestUtilities
    {
        private static IJavaScriptExecutor GetExecutor(IWebDriver driver)
        {
            return driver as IJavaScriptExecutor;
        }

        private static string GetUserAgent(IWebDriver driver)
        {
            try
            {
                return (string)GetExecutor(driver).ExecuteScript("return navigator.userAgent;");
            }
            catch (Exception)
            {
                // Some drivers will only execute JS once a page has been loaded. Since those
                // drivers aren't Firefox or IE, we don't worry about that here.
                //
                // Non-javascript-enabled HtmlUnit throws an UnsupportedOperationException here.
                // Let's just ignore that.
                return "";
            }
        }

        public static bool IsChrome(IWebDriver driver)
        {
            return GetUserAgent(driver).Contains("Chrome");
        }

        // todo: test this
        public static bool IsOldChromedriver(IWebDriver driver)
        {
            ICapabilities caps;
            try
            {
                caps = ((IHasCapabilities) driver).Capabilities;
            }
            catch (InvalidCastException e)
            {
                // Driver does not support capabilities -- not a chromedriver at all.
                return false;
            }
            var chromedriverVersion = (String)caps.GetCapability("chrome.chromedriverVersion");
            if (chromedriverVersion != null)
            {
                String[] versionMajorMinor = chromedriverVersion.Split('.');
                if (versionMajorMinor.Length > 1)
                {
                    try
                    {
                        return 20 < long.Parse(versionMajorMinor[0]);
                    }
                    catch (FormatException e)
                    {
                        // First component of the version is not a number -- not a chromedriver.
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool IsFirefox(IWebDriver driver)
        {
            return GetUserAgent(driver).Contains("Firefox");
        }

        public static bool IsInternetExplorer(IWebDriver driver)
        {
            return GetUserAgent(driver).Contains("MSIE");
        }

        public static bool IsIE6(IWebDriver driver)
        {
            return IsInternetExplorer(driver) && GetUserAgent(driver).Contains("MSIE 6");
        }

        public static bool IsIE10OrHigher(IWebDriver driver)
        {
            if (IsInternetExplorer(driver))
            {
                string jsToExecute = "return window.navigator.appVersion;";
                // IE9 is trident version 5.  IE9 is the start of new IE.
                string appVersionString = (string)GetExecutor(driver).ExecuteScript(jsToExecute);
                int tokenStart = appVersionString.IndexOf("MSIE ") + 5;
                int tokenEnd = appVersionString.IndexOf(";", tokenStart);
                if (tokenEnd - tokenStart > 0)
                {
                    string substring = appVersionString.Substring(tokenStart, tokenEnd - tokenStart);
                    double version = 0;
                    bool parsed = double.TryParse(substring, out version);
                    if (parsed)
                    {
                        return version >= 10;
                    }
                }
            }

            return false;
        }

        public static bool IsOldIE(IWebDriver driver)
        {
            try
            {
                string jsToExecute = "return parseInt(window.navigator.appVersion.split(' ')[0]);";
                // IE9 is trident version 5.  IE9 is the start of new IE.
                return (long)(GetExecutor(driver).ExecuteScript(jsToExecute)) < 5;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using NUnit.Framework;

namespace OpenQA.Selenium.Logging
{
    [TestFixture]
    [IgnoreBrowser(Browser.Android)]
    [IgnoreBrowser(Browser.HtmlUnit)]
    [IgnoreBrowser(Browser.IE)]
    [IgnoreBrowser(Browser.IPhone)]
    [IgnoreBrowser(Browser.Opera)]
    [IgnoreBrowser(Browser.PhantomJS)]
    public class AvailableLogsTest : DriverTestFixture
    {
        [Test]
        public void BrowserLogShouldBeEnabledByDefault()
        {
            if (TestUtilities.IsOldChromedriver(driver))
                Assert.Ignore("Old chromedriver doesn't support logging");

            var logTypes = driver.Manage().Logs().GetAvailableLogTypes();
            Assert.True(logTypes.Contains(LogType.Browser), "Browser logs should be enabled by default");
        }

        [Test]
        [NeedsFreshDriver]
        public void ClientLogShouldBeEnabledByDefault()
        {
            if (TestUtilities.IsOldChromedriver(driver))
                Assert.Ignore("Old chromedriver doesn't support logging");

            // Do one action to have *something* in the client logs.
            driver.Navigate().GoToUrl(formsPage);
            var logTypes = driver.Manage().Logs().GetAvailableLogTypes();
            Assert.True(logTypes.Contains(LogType.Client), "Client logs should be enabled by default");
            var foundExecutingStatement = false;
            var foundExecutedStatement = false;
            foreach (var logEntry in driver.Manage().Logs().Get(LogType.Client))
            {
                foundExecutingStatement |= logEntry.ToString().Contains("Executing: ");
                foundExecutedStatement |= logEntry.ToString().Contains("Executed: ");
            }
            Assert.True(foundExecutingStatement);
            Assert.True(foundExecutedStatement);
        }

        [Test]
        [IgnoreBrowser(Browser.Chrome, "Remove when chromedriver2 has it")]
        public void DriverLogShouldBeEnabledByDefault()
        {
            if (TestUtilities.IsOldChromedriver(driver))
                Assert.Ignore("Old chromedriver doesn't support logging");

            var logTypes = driver.Manage().Logs().GetAvailableLogTypes();
            Assert.True(logTypes.Contains(LogType.Driver), "Remote driver logs should be enabled by default");
        }

        [Test]
        public void ProfilerLogShouldBeDisabledByDefault()
        {
            if (TestUtilities.IsOldChromedriver(driver))
                Assert.Ignore("Old chromedriver doesn't support logging");

            var logTypes = driver.Manage().Logs().GetAvailableLogTypes();
            Assert.False(logTypes.Contains(LogType.Profiler), "Profiler logs should not be enabled by default");
        }

        // todo: make WebDriverBuilder
/*
        [Test]
        [IgnoreBrowser(Browser.Safari, "Safari does not support profiler logs")]
        public void ShouldBeAbleToEnableProfilerLog()
        {
            // assumeFalse(isOldChromedriver(driver));
            var caps = new DesiredCapabilities();
            caps.SetCapability(ENABLE_PROFILING_CAPABILITY, true);
            WebDriverBuilder builder = new WebDriverBuilder().setDesiredCapabilities(caps);
            localDriver = builder.get();
            var logTypes = localDriver.Manage().Logs().GetAvailableLogTypes();
            assertTrue("Profiler log should be enabled", logTypes.Contains(LogType.Profiler));
        }
*/

        [Test]
        public void ServerLogShouldBeEnabledByDefaultOnRemote()
        {
            // assumeTrue(Boolean.getBoolean("selenium.browser.remote"));
            var logTypes = driver.Manage().Logs().GetAvailableLogTypes();
            Assert.True(logTypes.Contains(LogType.Server), "Server logs should be enabled by default");
        }
    }
}
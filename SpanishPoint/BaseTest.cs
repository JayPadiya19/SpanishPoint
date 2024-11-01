using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanishPoint
{
    [TestClass]
    public abstract class BaseTest
    {
        public static IWebDriver driver;
        public static TestContext TestContext { get; set; }
        /// <summary>
        /// This Method is used to initialize chrome driver and maximize it.
        /// </summary>
        private static void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

            // Access the configuration value
            string? url = configuration["Settings:URL"];
            TestContext =testContext;
            InitializeChromeDriver();
            driver.Navigate().GoToUrl(url);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            driver.Close();
        }

    }
}

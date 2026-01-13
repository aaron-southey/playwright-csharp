using Microsoft.Playwright;
using NUnit.Framework;
using Config;
using System.IO;
using System.Text.Json;

namespace PlaywrightTests
{
    public abstract class BaseTest
    {
        protected PlaywrightConfig Config;
        protected IPage Page;
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        private static IBrowserContext _context;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            // Load config once globally
            var json = File.ReadAllText("appsettings.json");
            Config = JsonSerializer.Deserialize<PlaywrightConfig>(json)!;

            // Setup shared Playwright context
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Config?.Headless });
            _context = await _browser.NewContextAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Setting up test...");
            Page = await _context.NewPageAsync();
            Page.SetDefaultTimeout((float)(Config?.Timeout ?? 5000));
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Page != null)
            {
                await Page.CloseAsync();
            }
            TestContext.Out.WriteLine("*****\nTearing down test\n*****");
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {

            if (_context != null)
            {
                await _context.CloseAsync();
            }
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
            _playwright?.Dispose();
        }
    }
}
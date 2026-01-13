using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit.Framework;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

// Denotes Parallelizeable test
[Parallelizable(ParallelScope.Self)]

// Denotes Test Fixture
[TestFixture]

// Denotes in "SmokeTest" group, so we can filter the test runs
[Category("SmokeTests")] 
public class ExampleTest : BaseTest
{
    // Private field to hold the LoginPage instance
    private LoginPage loginPage;

    // Denotes the setup for this specific test class
    [SetUp]
    public void TestSetUp(){
        // Pages go here
        // Initializing class and assigning to variable
        loginPage = new LoginPage(Page);
    }

    // Denotes Specific test
    [Test]
    public async Task CanLoginToSauceLabsDemo()
    {
        await loginPage.NavigateToPageAsync();

        await loginPage.CompleteLoginFormAndSubmitAsync("standard_user", "secret_sauce");

        await Task.Delay(200000); // Just to visually see the logged in state briefly
    }

    // [Test]
    // public async Task CanGetToInstallationPageAndHasCorrectTitle()
    // {
    //     await loginPage.NavigateToPageAsync();

    //     // Click the get started link.
    //     await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

    //     // Expects page to have a heading with the name of Installation.
    //     await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    // } 
}
using Microsoft.Playwright;
using System.Threading.Tasks;

/*
* This is a specific page class which will allow us to interact with Login Page Specific elements
* Methods should be clear in what their intended use is
* This class extends the base class to ensure we get full use of the common methods, like clicking a button.
* That is so we can reduce duplication, even of the playwright methods
*/

namespace PlaywrightTests.Pages
{
    public class LoginPage : BasePage
    {
        private ILocator UsernameInput => Page.Locator("[data-test='username']");
        private ILocator PasswordInput => Page.Locator("[data-test='password']");
        private ILocator LoginButton => Page.Locator("[data-test='login-button']");

        public LoginPage(IPage page) : base(page){}

        public async Task NavigateToPageAsync()
        {
            await GoToUrlAsync("https://www.saucedemo.com/");
        }

        private async Task FillUsernameAsync(string username) => await UsernameInput.FillAsync(username);

        private async Task FillPasswordAsync(string password) => await PasswordInput.FillAsync(password);

        private async Task ClickLoginButtonAsync() => await LoginButton.ClickAsync();

        public async Task CompleteLoginFormAndSubmitAsync(string username, string password)
        {
            await this.FillUsernameAsync(username);
            await this.FillPasswordAsync(password);
            await this.ClickLoginButtonAsync();
        }
    }
}
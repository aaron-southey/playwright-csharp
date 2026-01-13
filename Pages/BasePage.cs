using Microsoft.Playwright;
using System.Threading.Tasks;

/* 
    * This is where all base commands should be stored, which related to page/browser elements.
    * Pages will extend from this class to use its base methods, and apply page specific assertions around them.
*/

namespace PlaywrightTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage Page;

        protected BasePage(IPage page)
        {
            Page = page;
        }

        public virtual async Task GoToUrlAsync(string url) => await Page.GotoAsync(url);

        public async Task ClickButtonByIdAsync(string buttonId) => await Page.ClickAsync($"#{buttonId}");
    }
}
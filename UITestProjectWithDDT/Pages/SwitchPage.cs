using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class SwitchPage : Form
    {
        private static readonly Button openNewTab = new Button(By.Id("new-tab-button"),"Open new tab button");
        private static readonly Button openAlert = new Button(By.Id("alert-button"), "Open alert button");

        public SwitchPage() : base(By.TagName("h1"), "Switch page") { }

        public void OpenAlert() 
        {
            openAlert.Click();
        }

        public void OpenNewTab() 
        {
            openNewTab.Click();
        }
    }
}

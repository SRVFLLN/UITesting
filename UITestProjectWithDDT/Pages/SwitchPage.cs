using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public class SwitchPage : Form
    {
        private static readonly ElementFactory _elementFactory = new ElementFactory();
        private static readonly Button openNewTab = _elementFactory.GetButton(By.Id("new-tab-button"),"Open new tab button");
        private static readonly Button openAlert = _elementFactory.GetButton(By.Id("alert-button"), "Open alert button");

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

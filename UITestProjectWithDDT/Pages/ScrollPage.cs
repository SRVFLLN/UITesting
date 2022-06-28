using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class ScrollPage : Form
    {
        private static readonly InputElement nameInput = new InputElement(By.XPath("//input[@id='name']"),"Name input element");
        private static readonly InputElement dateInput = new InputElement(By.XPath("//input[@id='date']"), "Date input element");

        public ScrollPage() : base(By.TagName("h1"), "Scroll page") { }

        public void SendNameAndData(string name, string date) 
        {
            nameInput.SendKeys(name);
            dateInput.SendKeys(date);
        }

        public string GetName() => nameInput.GetAttribute("value");

        public string GetData() => dateInput.GetAttribute("value");
    }
}

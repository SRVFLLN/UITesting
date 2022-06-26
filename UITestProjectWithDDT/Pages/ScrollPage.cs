using OpenQA.Selenium;
using System;

namespace UITestProjectWithDDT
{
    public class ScrollPage : Form
    {
        private static readonly ElementFactory _elementFactory = new ElementFactory();
        private static readonly InputElement nameInput = _elementFactory.GetInput(By.XPath("//input[@id='name']"),"Name input element");
        private static readonly InputElement dateInput = _elementFactory.GetInput(By.XPath("//input[@id='date']"), "Date input element");

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

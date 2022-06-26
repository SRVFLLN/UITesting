using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, name) { }
    }
}

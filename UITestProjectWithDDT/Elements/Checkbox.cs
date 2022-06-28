using OpenQA.Selenium;

namespace UITestProjectWithDDT.Elements
{
    public class Checkbox : BaseElement
    {
        public Checkbox(By locator, string name) : base(locator, name) { }

        public bool IsSelected => FindElement().Selected;
    }
}
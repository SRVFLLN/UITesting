using OpenQA.Selenium;

namespace UITestProjectWithDDT.Elements
{
    public class RadioButton : BaseElement
    {
        public RadioButton(By locator, string name) : base(locator, name) { }

        public bool IsSelected => FindElement().Selected;
    }
}

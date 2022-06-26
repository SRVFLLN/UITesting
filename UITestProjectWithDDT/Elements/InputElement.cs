using OpenQA.Selenium;
using System;

namespace UITestProjectWithDDT
{
    public class InputElement : BaseElement
    {
        public InputElement(By locator, string name) : base(locator, name) { }

        public void SendKeys(string textForInput)
        {
            try
            {
                FindElement().Clear();
                FindElement().SendKeys(textForInput);
                Logger.Info($"Into {Name} sendind text:", textForInput);
            }
            catch (Exception exception)
            {
                Logger.Error("Cannot send keys into element:",exception.Message);
            }
        }

        public void SendArrows(string arrow)
        {
            try
            {
                Logger.Info($"Into {Name} sendind arrow: {arrow}");
                FindElement().SendKeys(arrow);
            }
            catch (Exception exception) 
            {
                Logger.Error("Cannot send arrows into element:", exception.Message);
            }
        }
    }
}
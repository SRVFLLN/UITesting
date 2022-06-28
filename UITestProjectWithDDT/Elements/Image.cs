using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UITestProjectWithDDT.Elements
{
    public class Image : BaseElement
    {
        public Image(By locator, string name) : base(locator, name) { }

        public void DragDropImage(BaseElement targetElement) 
        {
            Logger.Info($"{Name} image dropped to {targetElement.Name}");
            Actions actions = new Actions(SingletonDriver.Source);
            actions.DragAndDrop(GetElement(), targetElement.GetElement()).Build().Perform();
        }
    }
}

using OpenQA.Selenium;
namespace UITestProjectWithDDT
{
    public class ElementFactory
    {
        public TextBox GetTextBox(By locator, string name) 
        {
            return new TextBox(locator, name);
        }

        public InputElement GetInput(By locator, string name) 
        {
            return new InputElement(locator, name);
        }

        public Link GetLink(By locator, string name) 
        {
            return new Link(locator, name);
        }

        public Button GetButton(By locator, string name)
        {
            return new Button(locator, name);
        }

        public Image GetImage(By locator, string name)
        {
            return new Image(locator, name);
        }
    }
}

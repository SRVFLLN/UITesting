using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public class DragDropPage : Form
    {
        private static readonly ElementFactory _elementFactory = new ElementFactory();
        private static readonly Image imageForDrag = _elementFactory.GetImage(By.XPath("//div[@id='image']//img"), "Selenium logo element");
        private static readonly TextBox boxForDrop = _elementFactory.GetTextBox(By.XPath("//div[@id='box']"), "Box element for drop image");
        private static readonly TextBox stateTextBox = _elementFactory.GetTextBox(By.XPath("//div[@id='box']/p"),"Text on box element");

        public DragDropPage() : base(By.TagName("img"), "Main page") { }

        public void DragDropImage() 
        {
            imageForDrag.DragDropImage(boxForDrop);
        }

        public string GetStateText() => stateTextBox.Text;
    }
}

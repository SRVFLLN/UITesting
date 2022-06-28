using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class DragDropPage : Form
    {
        private static readonly Image imageForDrag = new Image(By.XPath("//div[@id='image']//img"), "Selenium logo element");
        private static readonly TextBox boxForDrop = new TextBox(By.XPath("//div[@id='box']"), "Box element for drop image");
        private static readonly TextBox stateTextBox = new TextBox(By.XPath("//div[@id='box']/p"),"Text on box element");

        public DragDropPage() : base(By.TagName("img"), "Main page") { }

        public void DragDropImage() 
        {
            imageForDrag.DragDropImage(boxForDrop);
        }

        public string GetStateText() => stateTextBox.Text;
    }
}

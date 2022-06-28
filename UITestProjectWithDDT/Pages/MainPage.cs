using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class MainPage : Form
    {
        private static readonly Link _datepickerPageLink = new Link(By.XPath("//a[(@href='/datepicker') and not (contains(@class,'dropdown'))]"), "Link to Datepicker Page");
        private static readonly Link _dragNdropPageLink = new Link(By.XPath("//a[(@href='/dragdrop') and not (contains(@class,'dropdown'))]"), "Link to Drag and Drop Page");
        private static readonly Link _dropdownageLink = new Link(By.XPath("//a[(@href='/dropdown') and not (contains(@class,'dropdown'))]"), "Link to Dropdown Page");
        private static readonly Link _filePageLink = new Link(By.XPath("//a[(@href='/fileupload') and not (contains(@class,'dropdown'))]"), "Link to File Upload Page");
        private static readonly Link _modalPageLink = new Link(By.XPath("//a[(@href='/modal') and not (contains(@class,'dropdown'))]"), "Link to Modal Page");
        private static readonly Link _scrollPageLink = new Link(By.XPath("//a[(@href='/scroll') and not (contains(@class,'dropdown'))]"), "Link to Scroll Page");
        private static readonly Link _switchPageLink = new Link(By.XPath("//a[(@href='/switch-window') and not (contains(@class,'dropdown'))]"), "Link to Switch Window Page");
        private static readonly Link _webformPageLink = new Link(By.XPath("//a[(@href='/form') and not (contains(@class,'dropdown'))]"), "Link to Complete Web Form Page");

        public MainPage() : base(By.ClassName("display-3"), "Main page") { }

        public void GoToDatepickerPage() => _datepickerPageLink.Click();
        public void GoToDragdropPage() => _dragNdropPageLink.Click();
        public void GoToDropownPage() => _dropdownageLink.Click();
        public void GoToFileUploadPage() => _filePageLink.Click();
        public void GoToModalPage() => _modalPageLink.Click();
        public void GoToScrollPage() => _scrollPageLink.Click();
        public void GoToSwitchPage() => _switchPageLink.Click();
        public void GoToWebFormPage() => _webformPageLink.Click();
    }
}

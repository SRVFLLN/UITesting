using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class FileUploadPage : Form
    {
        private static readonly InputElement fileUpload = new InputElement(By.Id("file-upload-field"),"File upload input element");

        public FileUploadPage() : base(By.ClassName("form-control"), "File Upload page") { }

        public void UploadFile(string path) 
        {
            fileUpload.SendKeys(path);
        }

        public string GetNameOfUploadedFile() => fileUpload.GetAttribute("value");
    }
}

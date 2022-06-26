using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public class FileUploadPage : Form
    {
        private static readonly ElementFactory _elementFactory = new ElementFactory();
        private static readonly InputElement fileUpload = _elementFactory.GetInput(By.Id("file-upload-field"),"File upload input element");

        public FileUploadPage() : base(By.ClassName("form-control"), "File Upload page") { }

        public void UploadFile(string path) 
        {
            fileUpload.SendKeys(path);
        }

        public string GetNameOfUploadedFile() => fileUpload.GetAttribute("value");
    }
}

using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class ModalPage : Form
    {
        private static readonly Button openModalButton = new Button(By.Id("modal-button"),"Open modal button");
        private static readonly Button closeModalButton = new Button(By.XPath("//div[@class='modal-footer']//button[contains(@id,'close')]"), "Close modal button");
        private static readonly TextBox modalTitle = new TextBox(By.ClassName("modal-title"),"Modal title");

        public ModalPage() : base(By.Id("modal-button"), "Modal page") { }

        public void OpenModal()
        {
            openModalButton.Click();
        }

        public void CloseModal()
        {
            closeModalButton.Click(2);
            Waitings.WaitForElementIsNotDisplayed(closeModalButton);
        }

        public bool IsModalOpen() 
        {
            return modalTitle.IsDisplayed;
        }
    }
}

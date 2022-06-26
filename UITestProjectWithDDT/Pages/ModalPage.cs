using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public class ModalPage : Form
    {
        private static readonly ElementFactory _elementFactory = new ElementFactory();
        private static readonly Button openModalButton = _elementFactory.GetButton(By.Id("modal-button"),"Open modal button");
        private static readonly Button closeModalButton = _elementFactory.GetButton(By.XPath("//div[@class='modal-footer']//button[contains(@id,'close')]"), "Close modal button");
        private static readonly TextBox modalTitle = _elementFactory.GetTextBox(By.ClassName("modal-title"),"Modal title");

        public ModalPage() : base(By.Id("modal-button"), "Modal page") { }

        public void OpenModal() 
        {
            openModalButton.Click();
        }

        public void CloseModal()
        {
            closeModalButton.Click(3, new ElementClickInterceptedException());
            Waitings.WaitForElementIsNotDisplayed(closeModalButton);
        }

        public bool IsModalOpen() 
        {
            return modalTitle.IsDisplayed;
        }
    }
}

using OpenQA.Selenium;
using UITestProjectWithDDT.Elements;

namespace UITestProjectWithDDT.Pages
{
    public class WebFormPage : Form
    {
        private static readonly InputElement nameInput = new InputElement(By.Id("first-name"), "Name input element");
        private static readonly InputElement lnameInput = new InputElement(By.Id("last-name"), "Last name input element");
        private static readonly InputElement jobInput = new InputElement(By.Id("job-title"), "Job input element");
        private static readonly InputElement dateInput = new InputElement(By.Id("datepicker"), "Date input element");
        private static readonly Button expirienceListButton = new Button(By.Id("select-menu"), "Years list button");
        private static readonly Button submitButton = new Button(By.XPath("//a[@role='button']"), "Submit button");
        private static RadioButton educationLevel(string level) => new RadioButton(By.XPath($"//div[@class='input-group']//input[@id='radio-button-{level}']"),"Education input element");
        private static Checkbox sexInput(string sex) => new Checkbox(By.XPath($"//div[@class='input-group']//input[@id='checkbox-{sex}']"), "Sex input element");
        private static TextBox yearsElement(string expirience) => new TextBox(By.XPath($"//option[@value='{expirience}']"), "Years of expirience element");

        public WebFormPage() : base(By.XPath("//h1[contains(text(),'Complete Web Form')]"), "Web form page") { }

        public void FillWebForm(Human human) 
        {
            nameInput.SendKeys(human.Name);
            lnameInput.SendKeys(human.LName);
            jobInput.SendKeys(human.Job);
            educationLevel(human.Education).Click();
            sexInput(human.Sex).Click();
            expirienceListButton.Click();
            yearsElement(human.Experience).Click();
            dateInput.SendKeys(human.Date);
        }

        public string GetValuesFromForm(Human human) 
        {
            return string.Concat(new string[]
            {
                nameInput.Value,
                lnameInput.Value,
                jobInput.Value,
                educationLevel(human.Education).IsSelected ? educationLevel(human.Education).GetAttribute("value")[^1].ToString() : null,
                sexInput(human.Sex).IsSelected ? sexInput(human.Sex).GetAttribute("id")[^1].ToString() : null,
                human.Experience,
                dateInput.Value
            }) ;
        }
    }
}

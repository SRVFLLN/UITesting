using OpenQA.Selenium;
using System;

namespace UITestProjectWithDDT
{
    class DatepickerPage : Form
    {
        private static readonly ElementFactory _elementFactory = new ElementFactory();
        private static readonly InputElement dateInput = _elementFactory.GetInput(By.XPath("//input[@id='datepicker']"), "Date Input");
        private static readonly Button daySwitch = _elementFactory.GetButton(By.XPath("//div[contains(@class,'days')]//th[@class='datepicker-switch']"), "Day switch");
        private static readonly Button monthSwitch = _elementFactory.GetButton(By.XPath("//div[contains(@class,'months')]//th[@class='datepicker-switch']"), "Month switch");
        private static readonly Button yearsSwitch = _elementFactory.GetButton(By.XPath("//div[contains(@class,'years')]//th[@class='datepicker-switch']"), "Years switch");
        private static readonly Button decadesSwitch = _elementFactory.GetButton(By.XPath("//div[contains(@class,'decades')]//th[@class='datepicker-switch']"), "Decades switch");
        private static readonly Button previousCenturies = _elementFactory.GetButton(By.XPath("//div[contains(@class,'centuries')]//th[@class='prev']"),"Previous centuries switch");
        private static readonly Button nextCenturies = _elementFactory.GetButton(By.XPath("//div[contains(@class,'centuries')]//th[@class='next']"), "Next centuries switch");
        private static Button dropdownElement(string data) => _elementFactory.GetButton(By.XPath($"//div[contains(@class,'dropdown')]//span[contains(text(),'{data}')]"), $"Button with text '{data}'");
        private static Button dayElement(string day) => _elementFactory.GetButton(By.XPath($"//div[contains(@class,'dropdown')]//td[@class='day' and text()='{day}']"), $"Button with {day} day");
        private static Button roundedUpElement(string time) => _elementFactory.GetButton(By.XPath($"//div[contains(@class,'dropdown')]//span[@class='{time} new']"), "rounded up element");
        private static Button roundedDownElement(string time) => _elementFactory.GetButton(By.XPath($"//div[contains(@class,'dropdown')]//span[@class='{time} old']"), "rounded up element");

        public DatepickerPage() : base(By.TagName("h1"), "Page body header") { }

        public void PickTheDate(DateTime date) 
        {
            dateInput.Click();
            ChooseYear(date.Year);
            ChooseMonth(date.ToString("MMM"));
            ChooseDay(date.Day);
        }

        public string GetDateFromDatepicker() 
        {
            return dateInput.Text;
        }

        private void ChooseYear(int year) 
        {
            daySwitch.Click();
            int roundedUpYear;
            int roundedDownYear;
            if (year != DateTime.Now.Year) 
            {
                monthSwitch.Click();
            Years:
                roundedUpYear = Convert.ToInt32(roundedUpElement("year").Text);
                roundedDownYear = Convert.ToInt32(roundedDownElement("year").Text);
                if (year > roundedUpYear | year < roundedDownYear)
                {
                    yearsSwitch.Click(); 
                }
                else
                {
                    dropdownElement(year.ToString()).Click();
                    return;
                }
            Decades:
                roundedUpYear = Convert.ToInt32(roundedUpElement("decade").Text);
                roundedDownYear = Convert.ToInt32(roundedDownElement("decade").Text);
                if (year > roundedUpYear | year < roundedDownYear)
                {
                    decadesSwitch.Click();
                }
                else
                {
                    dropdownElement((year - year % 10).ToString()).Click();
                    goto Years;
                }
                roundedUpYear = Convert.ToInt32(roundedUpElement("century").Text);
                roundedDownYear = Convert.ToInt32(roundedDownElement("century").Text);
                if (year > roundedUpYear) 
                {
                    while (!dropdownElement((year - year % 100).ToString()).IsDisplayed)
                    {
                        nextCenturies.Click();
                    }
                    dropdownElement((year - year % 100).ToString()).Click();
                    goto Decades;
                }
                if (year < roundedDownYear) 
                {
                    while (!dropdownElement((year - year % 100).ToString()).IsDisplayed)
                    {
                        previousCenturies.Click();
                    }
                    dropdownElement((year - year % 100).ToString()).Click();
                    goto Decades;
                }
                else
                {
                    dropdownElement((year - year % 100).ToString()).Click();
                    goto Decades;
                }
            }
        }
        private void ChooseMonth(string month) 
        {
            dropdownElement(month).Click();
        }
        private void ChooseDay(int day) 
        {
            dayElement(day.ToString()).Click();
        }
    }
}

using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public static class Waitings
    {
        private static readonly WebDriverWait wait = new WebDriverWait(SingletonDriver.Source, TimeSpan.FromSeconds(1));

        public static void WaitForElementIsNotDisplayed(BaseElement element) 
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(400);
            wait.Until(drv => SingletonDriver.Source.FindElement(element.Locator).Displayed == false);
        }

        public static void WaitForElementIsDisplayed(BaseElement element) 
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(400);
            wait.Until(ExpectedConditions.ElementIsVisible(element.Locator));
        }

        public static void WaitUntilElementBeClickable(BaseElement element) 
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(400);
            wait.Until(ExpectedConditions.ElementToBeSelected(element.Locator));
        }

        public static void WaitUntilPageIsOpen(By locator) 
        {
            wait.PollingInterval = TimeSpan.FromMilliseconds(400);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitUntilAlertIsPresent() 
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}

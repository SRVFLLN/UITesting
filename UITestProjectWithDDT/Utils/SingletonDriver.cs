﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;

namespace UITestProjectWithDDT
{
    public class SingletonDriver
    {
        private static IWebDriver driver = null;

        private SingletonDriver() 
        { 
            driver = new ChromeDriver(Directory.GetCurrentDirectory() + "/Resources"); 
            Logger.Info("Starting browser...");
        }

        public static IWebDriver Source 
        {
            get 
            {  
                if (driver == null) 
                {
                    new SingletonDriver();
                }
                return driver;
            }
        }

        public static void Quit() 
        {
            driver.Quit();
            SingletonDriver.Source.Dispose();
            driver = null;
            Logger.Info("Close browser...");
        }
    }
}

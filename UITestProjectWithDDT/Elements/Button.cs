﻿using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name) { }
    }
}
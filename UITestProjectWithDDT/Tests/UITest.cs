using NUnit.Framework;
using System;
using System.Collections.Generic;
using UITestProjectWithDDT.Pages;

namespace UITestProjectWithDDT
{
    public class Tests : BaseTest
    {
        [Test]
        public void DatepickerTest()
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToDatepickerPage();
            DatepickerPage datepickerPage = new DatepickerPage();
            Assert.IsTrue(datepickerPage.IsPageOpen, "Datepicker page not opened");
            DateTime date = new DateTime(new Random().Next(0, 10000),new Random().Next(1,12),new Random().Next(1,31));
            datepickerPage.PickTheDate(date);
            StringAssert.Contains(datepickerPage.GetDateFromDatepicker(),date.ToString("MM/dd/yyyy"),"Date not equal");
        }

        [Test]
        public void DragDropTest() 
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToDragdropPage();
            DragDropPage dragDropPage = new DragDropPage();
            Assert.IsTrue(dragDropPage.IsPageOpen, "Drag N Drop Page is not opened");
            SingletonDriver.Source.Navigate().Refresh();
            Assert.IsTrue(dragDropPage.IsPageOpen, "Drag N Drop Page is not refreshed succesfuly");
            dragDropPage.DragDropImage();
            StringAssert.Contains(dragDropPage.GetStateText(), "Dropped!", "Image is not dropped");
        }

        [Test]
        public void FileUploadTest() 
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToFileUploadPage();
            FileUploadPage fileUploadPage = new FileUploadPage();
            Assert.IsTrue(fileUploadPage.IsPageOpen, "File Upload page not opened");
            fileUploadPage.UploadFile(ConfigTool.GetTagValue("filename"));
            StringAssert.Contains(ConfigTool.GetTagValue("filename"), fileUploadPage.GetNameOfUploadedFile());
        }

        [Test]
        public void ModalTest() 
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToModalPage();
            ModalPage modalPage = new ModalPage();
            Assert.IsTrue(modalPage.IsPageOpen, "Modal page not opened");
            modalPage.OpenModal();
            Assert.IsTrue(modalPage.IsModalOpen(), "Modal not opened");
            modalPage.CloseModal();
            Assert.IsFalse(modalPage.IsModalOpen(), "Modal not closed");
        }

        [Test]
        public void ScrollTest() 
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToScrollPage();
            ScrollPage scrollPage = new ScrollPage();
            Assert.IsTrue(scrollPage.IsPageOpen, "Scroll page not opened");
            string date = new DateTime(new Random().Next(0, 10000), new Random().Next(1, 12), new Random().Next(1, 31)).ToString("d");
            string name = ConfigTool.GetTagValue("text");
            scrollPage.PageActions.ScrollToBottom();           
            scrollPage.SendNameAndData(name, date);
            Assert.Multiple(() =>
            {
                StringAssert.Contains(name, scrollPage.GetName(), "Name is wrong");
                StringAssert.Contains(date, scrollPage.GetData(), "Date is wrong");
            });
        }

        [Test]
        public void SwitchTest() 
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToSwitchPage();
            SwitchPage switchPage = new SwitchPage();
            Assert.IsTrue(switchPage.IsPageOpen, "Switch page not opened");
            switchPage.OpenAlert();
            Assert.AreEqual("This is a test alert!", AlertsActions.GetTextFromAlert(), "Not expected text on the alert");
            AlertsActions.OK();
            Assert.IsTrue(AlertsActions.IsAlertClosed(), "Alert not closed");
            string mainTab = SingletonDriver.Source.CurrentWindowHandle;
            switchPage.OpenNewTab();
            Assert.IsTrue(SingletonDriver.Source.WindowHandles.Count > 1, "New tab is not open");
            foreach (string window in SingletonDriver.Source.WindowHandles)
            {
                if (mainTab != window)
                {
                    SingletonDriver.Source.SwitchTo().Window(window);
                    break;
                }
            }
            Assert.IsTrue(SingletonDriver.Source.Url.Contains(ConfigTool.GetTagValue("startUrl")), "Wrong tab selected");
            SingletonDriver.Source.Close();
            SingletonDriver.Source.SwitchTo().Window(mainTab);
            Assert.IsTrue(switchPage.IsPageOpen, "Tab not closed");
        }

        private static List<Human> Source => Deserialization.GetModelsFromFile<Human>(ConfigTool.GetTagValue("sourcename"));

        [Test, TestCaseSource("Source")]
        public void WebFormTest(Human human) 
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsPageOpen, "Main page not opened");
            mainPage.GoToWebFormPage();
            WebFormPage webFormPage = new WebFormPage();
            Assert.IsTrue(webFormPage.IsPageOpen, "Web Form page not opened");
            webFormPage.FillWebForm(human);
            Assert.AreEqual(human.ToString(), webFormPage.GetValuesFromForm(human), "Form filled incorrectly");
        }
    }
}
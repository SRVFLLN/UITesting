using NUnit.Framework;

namespace UITestProjectWithDDT
{
    public class BaseTest
    {
        [SetUp]
        public void ConditionsBeforeEachTest() 
        {
            SingletonDriver.Source.Navigate().GoToUrl(ConfigTool.GetTagValue("startUrl"));
            Logger.LoadConfiguration();
        }

        [TearDown]
        public void ConditionAfterEachTest() 
        {
            SingletonDriver.Quit();
        }
    }
}

using OpenQA.Selenium;

namespace UITestProjectWithDDT
{
    public static class AlertsActions
    {
        private static IAlert Alert 
        {
            get 
            {
                Waitings.WaitUntilAlertIsPresent();
                return SingletonDriver.Source.SwitchTo().Alert();
            }
        }

        public static void Cancel()
        {
            Logger.Info($"Click Cancel on alert");
            Alert.Dismiss();
        }

        public static void OK()
        {
            Logger.Info($"Click OK on alert");
            Alert.Accept();
        }

        public static void SendKeys(string words)
        {
            Logger.Info($"Send {words} to alert");
            Alert.SendKeys(words);
        }

        public static string GetTextFromAlert()
        {
            return Alert.Text;
        }

        public static bool IsAlertClosed()
        {
            try
            {
                SingletonDriver.Source.SwitchTo().Alert();
                return false;
            }
            catch (NoAlertPresentException)
            {
                return true;
            }
        }
    }
}
using System;
using System.Threading;
using OpenQA.Selenium;

namespace SeleniumWebDriverTest
{
    public static class ExtensionMethods
    {
        public static void WaitForAjax(this IWebDriver driver, int timeoutSecs = 10, bool throwException = false)
        {
            for (var i = 0; i < timeoutSecs; i++)
            {
                var ajaxIsComplete = (bool) ((IJavaScriptExecutor) driver)
                    .ExecuteScript("return jQuery.active == 0");
                
                if (ajaxIsComplete) return;

                Thread.Sleep(1000);
            }
            if (throwException)
                throw new Exception("WebDriver timed out waiting for AJAX call to complete");
        }
    }
}
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace SeleniumWebDriverTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void NavegateToGoogleSiteSearchAndPrint()
        {
            var scj = new ScreenCaptureJob();
            var chromeDriver = new ChromeDriver();

            // config ScreenCaptureJob
            scj.OutputScreenCaptureFileName = @"c:\Temp\Selenium\Recording\NavegateToGoogleSiteSearchAndPrint.wmv";
            scj.Start(); //  starting recording
            chromeDriver.Manage().Window.Maximize();


            chromeDriver.Navigate().GoToUrl("http://www.google.com");
            chromeDriver.FindElement(By.Name("q")).SendKeys("test selenium web driver");
            chromeDriver.FindElement(By.Name("btnK")).Submit();

            Thread.Sleep(1500);

            chromeDriver.FindElement(By.CssSelector("#rso > div > div > div:nth-child(1) > div > div > h3 > a"))
                .Click();

            Thread.Sleep(1500);

            // print
            ((ITakesScreenshot) chromeDriver)
                .GetScreenshot()
                .SaveAsFile(@"C:\Temp\Selenium\Screenshot\Screenshot.png");


            Thread.Sleep(2000);
            scj.Stop();
            chromeDriver.Close();
        }

        [Test]
        public void SearchAndClickSaveImageInGoogleSite()
        {
            var scj = new ScreenCaptureJob();
            var chromeDriver = new ChromeDriver();

            // config ScreenCaptureJob
            scj.OutputScreenCaptureFileName = @"c:\Temp\Selenium\Recording\SearchAndClickSaveImageInGoogleSite.wmv";
            scj.Start(); //  starting recording
            chromeDriver.Manage().Window.Maximize();

            chromeDriver.Navigate().GoToUrl("http://www.google.com.br");

            chromeDriver.FindElement(By.Name("q")).SendKeys("funny cats");

            chromeDriver.FindElement(By.Name("btnK")).Submit();

            chromeDriver.FindElement(By.PartialLinkText("Imagens")).Click();

            chromeDriver.FindElement(By.Name("kNxxpnFk0aZAuM:")).Click();

            Thread.Sleep(2000);

            ((ITakesScreenshot) chromeDriver)
                .GetScreenshot()
                .SaveAsFile(@"C:\Temp\Selenium\Screenshot\SearchAndClickSaveImageInGoogleSiteBeforeSave.png");

            chromeDriver.FindElement(By.PartialLinkText("Salvar")).Click();


            ((ITakesScreenshot) chromeDriver)
                .GetScreenshot()
                .SaveAsFile(@"C:\Temp\Selenium\Screenshot\SearchAndClickSaveImageInGoogleSiteAfterSave.png");

            Thread.Sleep(2000);
            scj.Stop();
            chromeDriver.Close();
        }

        [Test]
        public void DropDownSwitchTest()
        {
            const string url = "http://automationpractice.com/index.php?id_category=5&controller=category#/";

            var scj = new ScreenCaptureJob();
            var chrome = new ChromeDriver();

            // config ScreenCaptureJob
            scj.OutputScreenCaptureFileName = @"c:\Temp\Selenium\Recording\DropDownTest.wmv";
            scj.Start(); //  starting recording
            chrome.Manage().Window.Maximize();

            chrome.Navigate().GoToUrl(url);

            var dropDownElement = new SelectElement(chrome.FindElement(By.Id("selectProductSort")));
            var dropDownOptions = dropDownElement.Options;

            foreach (var option in dropDownOptions)
            {
                option.Click();
                chrome.WaitForAjax(10);
            }

            Thread.Sleep(1500);
            scj.Stop();
            chrome.Close();
        }
    }
}
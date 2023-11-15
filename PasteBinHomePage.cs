using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask2
{
    public class PasteBinHomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private readonly Data data;

        public PasteBinHomePage(IWebDriver driver, Data data)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.data = data;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        IWebElement pasteButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'paste')]")));
        IWebElement GetSyntaxHighlightingButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Syntax Highlighting')]/../div/label")));
        IWebElement pasteField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@id='postform-text']")));
        IWebElement cookieButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class, 'cookie-button')]")));
        IWebElement proGuestButton => driver.FindElement(By.XPath("//div[@title='Close Me']"));
        IWebElement syntaxHighLightingDropBoxButton => driver.FindElement(By.XPath("//span[@id='select2-postform-format-container']"));
        IWebElement pasteExpirationDropBoxButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-postform-expiration-container']")));
        IWebElement Expiration10MButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[contains(@id, '10M')]")));
        IWebElement postFormNameInput => driver.FindElement(By.XPath("//input[@id='postform-name']"));
        IWebElement CreateNewPasteButton => driver.FindElement(By.XPath("//button[contains(text(), 'Create New Paste')]"));
        IWebElement browserPageTitleWithCorrectText => wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(), 'how to gain dominance among developers')]")));
        IWebElement syntaxHighLightingIndicationButton => wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(), 'Bash')]")));
        IWebElement elementWhichContainsCode => driver.FindElement(By.XPath("//span[contains(text(), 'New Sheriff in Town')]"));

        public void GetSyntaxHighlighting()
        {
            GetSyntaxHighlightingButton.Click();
        }

        public void clickPaste()
        {

        }

        public void InsertCode()
        {              
            cookieButton.Click();
            proGuestButton.Click();
            pasteButton.Click();
            pasteField.Click();
            pasteField.SendKeys(data.Code);
        }

        public void SelectSyntaxHighLighting()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", GetSyntaxHighlightingButton);
            syntaxHighLightingDropBoxButton.Click();
            Actions action = new Actions(driver);
            action.SendKeys("Bash").SendKeys(Keys.Enter).Build().Perform();            
        }

        public void SelectPasteExpiration()
        {
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", pasteExpirationDropBoxButton);
            pasteExpirationDropBoxButton.Click();
            Expiration10MButton.Click();
        }

        public void PostNameInput()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            postFormNameInput.Click();
            postFormNameInput.SendKeys("how to gain dominance among developers");
        }

        public void CreateNewPaste()
        {
            CreateNewPasteButton.Click();
        }

        public bool TitleCheck()
        {
            if (browserPageTitleWithCorrectText.Displayed)
                return true;
            else
                return false;
        }

        public bool SyntaxHighLightingCheck()
        {
            if (syntaxHighLightingIndicationButton.Displayed)
                return true;
            else
                return false;
        }

        public bool CodeCheck()
        {
            if (elementWhichContainsCode.Displayed)
                return true;
            else
                return false;
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTask2
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
      
        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
        }

        

        [Test]
        public void CreateNewPasteOnPasteBin()
        {
            Data data = new Data();
            PasteBinHomePage homePage = new PasteBinHomePage(driver, data);
            driver.Navigate().GoToUrl("https://pastebin.com/");
            //Console.ReadLine();
            //homePage.GetSyntaxHighlighting();

            homePage.InsertCode();
            homePage.SelectSyntaxHighLighting();
            homePage.SelectPasteExpiration();
            homePage.PostNameInput();
            homePage.CreateNewPaste();
            
            //Console.ReadLine();
            
            Assert.IsTrue(homePage.TitleCheck() && homePage.SyntaxHighLightingCheck() && homePage.CodeCheck());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
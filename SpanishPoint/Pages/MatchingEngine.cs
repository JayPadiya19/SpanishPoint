using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpanishPoint.Pages
{
    public class MatchingEngine : BaseTest
    {
        public IWebElement Modules = driver.FindElement(By.XPath("//a[text()='Modules']"));

        public IWebElement RepertoireManagementModule = driver.FindElement(By.XPath("//a[text()='Repertoire Management Module']"));
     
        /// <summary>
        /// This Method is use to move cursor to modules 
        /// </summary>
        public void MoveToModules()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(Modules).Perform();
        }

    }
}

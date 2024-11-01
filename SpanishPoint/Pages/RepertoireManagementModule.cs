using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanishPoint.Pages
{
    public class RepertoireManagementModule : BaseTest
    {
        private IWebElement TypeOfProductSupport;
        
        private IWebElement ProductSupport;
        public IWebElement productSupport
        {
            get
            {
                return ProductSupport = driver.FindElement(By.XPath("//span[text()='Products Supported']"));
            }
            set
            {
                ProductSupport = value;
            }
        }
        public IWebElement typeOfProductSupport
        {
            get 
            {
                return TypeOfProductSupport = driver.FindElement(By.XPath("//h3[text()='There are several types of Product Supported:']"));
            }
            set 
            {
                TypeOfProductSupport = value;
            }
        }

        /// <summary>
        /// This Method is used to scroll the scrollbar down 
        /// </summary>
        /// <param name="distanceInPixel"></param>
        public void ScrollUsingJavaScript(int distanceInPixel)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, " + distanceInPixel + ");");

        }
     /// <summary>
     /// This Method is use to validate product support type
     /// </summary>
     /// <param name="expectValue"></param>
     /// <returns>return true if it is validate successfull else false</returns>
        public bool verifyProductSupport(string expectValue)
        {
            //Wait untill element load
            for (int i = 0; i < 20; i++)
            {
                //Break for loop if element displayed
                if (typeOfProductSupport.Displayed)
                {
                    break;
                }
                //Wait for 5 milisecond
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                //Scroll down to get the element
                ScrollUsingJavaScript(20);
            }
            //Get actual value
            string actualText = typeOfProductSupport.Text;
            //Retrun true if value matches else false.
            return expectValue.Equals(actualText);
        }


    }
}

using SpanishPoint.Pages;

namespace SpanishPoint
{
    [TestClass]
    public class RepertoireManagementModuleTest :BaseTest
    {
         MatchingEngine engine;
         RepertoireManagementModule repertoireManagementModule;
       
        [TestInitialize]
        public  void TestInitial()
        {
            engine = new MatchingEngine();
            repertoireManagementModule = new RepertoireManagementModule();
        }
         

        [TestMethod]
        [Description("Verify Several type of product message on Repertoire Management Module page")]
        public void VerifySeveralTypeOfProduct()
        {
            //Step 2 Expand ‘Modules’ in the header section
            engine.MoveToModules();
            //Step 3 Click ‘Repertoire Management Module’ from the menu
            engine.RepertoireManagementModule.Click();
            //Step 4 Scroll to the ‘Additional Features’ section
            repertoireManagementModule.ScrollUsingJavaScript(1500);
            //Step 5 Click ‘Products Supported’
            repertoireManagementModule.productSupport.Click();
            
            repertoireManagementModule.ScrollUsingJavaScript(150);

            bool verifyMessage = repertoireManagementModule.verifyProductSupport("There are several types of Product Supported:");
            //Step 6 Assert on the list of supported products under the heading ‘There are several types of Product Supported:
            Assert.IsTrue(verifyMessage, "There are several types of Product Supported verify successfull");

        }
    }
}
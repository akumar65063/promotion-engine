using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Promotion;
namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionEngineTest
    {
        private PromotionEngine.Promotion.PromotionEngine promotionEngine = new PromotionEngine.Promotion.PromotionEngine();

        private double amountAfterPromotions;

        [TestMethod]
        public void Test_GetTotalAmountAfterPromotions_With_Scenario_A()
        {
            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 100);
        }

        [TestMethod]
        public void Test_GetTotalAmountAfterPromotions_With_Scenario_B()
        {
            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 370);
        }

        [TestMethod]
        public void Test_GetTotalAmountAfterPromotions_With_Scenario_C()
        {

            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 280);
            
        }

    }
}

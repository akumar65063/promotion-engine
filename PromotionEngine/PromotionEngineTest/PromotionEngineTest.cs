using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Promotion;
using PromotionEngine.Models;
using PromotionEngine.Promotion.PromotionTypes;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionEngineTest
    {
        private PromotionEngine.Promotion.PromotionEngine promotionEngine;

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
            var promotionList = BuildPromotionList();
            promotionEngine = new PromotionEngine.Promotion.PromotionEngine(new Order(), promotionList);

            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 370);
        }

        [TestMethod]
        public void Test_GetTotalAmountAfterPromotions_With_Scenario_C()
        {

            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 280);
            
        }

        private List<IPromotion> BuildPromotionList()
        {
            var activePromotions = new List<IPromotion>();

            activePromotions.Add(new BundledPromotion('A', 3, 130));
            activePromotions.Add(new BundledPromotion('B', 2, 45));
            activePromotions.Add(new PairedPromotion('C', 'D', 30));

            return activePromotions;
        }


    }
}

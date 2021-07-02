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
            var itemsWithPrice = GetItemsWithPrice();

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


        //The list of all the active promotions to be passed to the promotion engine 
        private List<IPromotion> BuildPromotionList()
        {
            var activePromotions = new List<IPromotion>();

            activePromotions.Add(new BundledPromotion('A', 3, 130));
            activePromotions.Add(new BundledPromotion('B', 2, 45));
            activePromotions.Add(new PairedPromotion('C', 'D', 30));

            return activePromotions;
        }

        

        private static List<Item> GetItemsWithPrice()
        {
            var items = new List<Item>();
            items.Add(new Item { SKU = 'A', Price = 50 });
            items.Add(new Item { SKU = 'B', Price = 30 });
            items.Add(new Item { SKU = 'C', Price = 20 });
            items.Add(new Item { SKU = 'D', Price = 15 });

            return items;
        }


    }
}

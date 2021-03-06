using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Promotion;
using PromotionEngine.Models;
using PromotionEngine.Promotion.PromotionTypes;
using System.Collections.Generic;
using System.Linq;

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
            var cartItems = new List<Item>() { new Item { SKU='A'},
                                               new Item { SKU='B'},                                     
                                               new Item { SKU='C'},                                                                            
                                             };

            var promotionList = BuildPromotionList();
     
            var order = BuildOrder(cartItems);

            promotionEngine = new PromotionEngine.Promotion.PromotionEngine(order, promotionList);

            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 100);
        }

        [TestMethod]
        public void Test_GetTotalAmountAfterPromotions_With_Scenario_B()
        {
            var cartItems =  new List<Item>() { new Item { SKU='A'},
                                                new Item { SKU='A'},
                                                new Item { SKU='A'},
                                                new Item { SKU='A'},
                                                new Item { SKU='A'},
                                                
                                                new Item { SKU='B'},
                                                new Item { SKU='B'},
                                                new Item { SKU='B'},
                                                new Item { SKU='B'},
                                                new Item { SKU='B'},
                                                
                                                new Item { SKU='C'},                                    
                                                };

            var promotionList = BuildPromotionList();

            var order = BuildOrder(cartItems);


            promotionEngine = new PromotionEngine.Promotion.PromotionEngine(order, promotionList);

            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 370);
        }

        [TestMethod]
        public void Test_GetTotalAmountAfterPromotions_With_Scenario_C()
        {
            var cartItems = new List<Item>() { new Item { SKU='A'},
                                               new Item { SKU='A'},
                                               new Item { SKU='A'},
                                               
                                               
                                               new Item { SKU='B'},
                                               new Item { SKU='B'},
                                               new Item { SKU='B'},
                                               new Item { SKU='B'},
                                               new Item { SKU='B'},
                                               
                                               new Item { SKU='C'},

                                               new Item { SKU='D'},
                                               };

            var promotionList = BuildPromotionList();

            var order = BuildOrder(cartItems);
            promotionEngine = new PromotionEngine.Promotion.PromotionEngine(order, promotionList);
            amountAfterPromotions = promotionEngine.GetTotalAmountAfterPromotions();

            Assert.AreEqual(amountAfterPromotions, 280);
            
        }


        #region private methods to build the test input data
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

        //This method will build the orders so that it contains the price of
        //each item against the items in the order
        private Order BuildOrder(List<Item> cartItems)
        {

            var itemPriceList = GetItemsWithPrice();

            var order = new Order();

            order.Items = (from item in itemPriceList
                           join cart in cartItems
                           on item.SKU equals cart.SKU
                           select new Item { SKU = cart.SKU, Price = item.Price }).ToList();

            return order;
        }
        #endregion private methods to build the test input data


    }
}

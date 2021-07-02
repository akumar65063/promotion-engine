using System;
using System.Collections.Generic;
using PromotionEngine.Models;
using PromotionEngine.Promotion.PromotionTypes;

namespace PromotionEngine.Promotion
{
    public class PromotionEngine
    {
        private List<IPromotion> promotionList;
        private Order order;
        private double totalAmountWithoutPromotions;
        private double totalDiscount;
        private double amountToBePaidByCustomer;

        //PromotionEngine should get the Order and the
        //List of Promotions to be applied
        public PromotionEngine(Order order, List<IPromotion> promotionList)
        {
            this.promotionList = promotionList;
            this.order = order;
        }

        //Returns the total amount to be paied by customer after applying all applicable discounts
        public double GetTotalAmountAfterPromotions()
        {

            totalAmountWithoutPromotions = GetTotalAmountWithoutPromotions();
            totalDiscount = GetDiscountAmountAfterAllPromotions();
            amountToBePaidByCustomer = totalAmountWithoutPromotions - totalDiscount;
            return amountToBePaidByCustomer;

        }

        //Calculates the total cost by summing the price of each item in the order
        private double GetTotalAmountWithoutPromotions()
        {
            foreach (var item in order.Items)
                totalAmountWithoutPromotions += item.Price;

            return totalAmountWithoutPromotions;
        }

        //Calculates the total discount after running all the applied promotions.
        private double GetDiscountAmountAfterAllPromotions()
        {
            double discountAmount = 0;

            foreach (var promotion in promotionList)
            {
                discountAmount += promotion.GetPromotionDiscount(order);
            }

            return discountAmount;


        }
    }
}

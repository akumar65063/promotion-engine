﻿using System;
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

        public double GetTotalAmountAfterPromotions()
        {

            return 0;

        }

        //Calculates the total cost by summing the price of each item in the order
        private double GetTotalAmountWithoutPromotions()
        {
            foreach (Item item in order.Items)
                totalAmountWithoutPromotions += item.Price;

            return totalAmountWithoutPromotions;
        }
    }
}

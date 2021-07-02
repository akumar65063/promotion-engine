using System;
using PromotionEngine.Models;

namespace PromotionEngine.Promotion.PromotionTypes
{
    public class PairedPromotion:IPromotion
    {
        private char _firstItemSku, _secondItemSku;
        private double _priceForPair;

        public PairedPromotion(char firstItemSku, char secondItemSku, double priceforPair)
        {
            _firstItemSku = firstItemSku;
            _secondItemSku = secondItemSku;
            _priceForPair = priceforPair;
        }


        //Returns the amount to be discounted after applying
        //this promotion
        public double GetPromotionDiscount(Order order)
        {
            return 0;
        }
    }
}

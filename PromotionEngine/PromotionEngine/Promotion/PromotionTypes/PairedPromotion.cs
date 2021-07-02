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
        //paired promotion
        public double GetPromotionDiscount(Order order)
        {
            double priceOfItem1, priceOfItem2, amountWithoutDiscount, amountWithDiscount;
            int countOfItem1, countOfItem2, numberOfPairs;

            if (order.Items.FindAll(x => x.SKU == _firstItemSku).Count > 0 && order.Items.FindAll(x => x.SKU == _secondItemSku).Count > 0)
            {

                priceOfItem1 = order.Items.Find(x => x.SKU == _firstItemSku).Price;

                priceOfItem2 = order.Items.Find(x => x.SKU == _secondItemSku).Price;

                countOfItem1 = order.Items.FindAll(x => x.SKU == _firstItemSku).Count;

                countOfItem2 = order.Items.FindAll(x => x.SKU == _secondItemSku).Count;

                numberOfPairs = Math.Min(countOfItem1, countOfItem2);

                amountWithoutDiscount = (priceOfItem1 + priceOfItem2) * numberOfPairs;

                amountWithDiscount = _priceForPair * numberOfPairs;

                return amountWithoutDiscount - amountWithDiscount;

            }

            return 0;
        }
    }
}

using System;
namespace PromotionEngine.Promotion.PromotionTypes
{
    public class BundledPromotion:IPromotion
    {
        private char _itemSKU;
        private int _itemCountInOneBundle;
        private double _priceForBundle;


        public BundledPromotion(char sku, int itemCount, double priceForBundle)
        {
            _itemSKU = sku;
            _itemCountInOneBundle = itemCount;
            _priceForBundle = priceForBundle;
        }


        //Returns the amount to be discounted after applying
        //this promotion
        public double GetPromotionDiscount()
        {
            return 0;

        }
    }
}

using System;
namespace PromotionEngine.Promotion.PromotionTypes
{
    public class BundledPromotion
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

        public double GetPromotionDiscount()
        {
            return 0;

        }
    }
}

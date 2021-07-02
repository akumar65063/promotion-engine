using System;
namespace PromotionEngine.Promotion.PromotionTypes
{
    public class PairedPromotion
    {
        private char _firstItemSku, _secondItemSku;
        private double _priceForPair;

        public PairedPromotion(char firstItemSku, char secondItemSku, double priceforPair)
        {
            _firstItemSku = firstItemSku;
            _secondItemSku = secondItemSku;
            _priceForPair = priceforPair;
        }

        public double GetPromotionDiscount()
        {
            return 0;
        }
    }
}

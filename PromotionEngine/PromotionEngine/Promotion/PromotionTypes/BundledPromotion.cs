using System;
using PromotionEngine.Models;

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
        public double GetPromotionDiscount(Order order)
        {
            double priceOfItem, amountWithoutDiscount, amountWithDiscount, totalDiscount;
            int countOfItemInOrder, numberOfBundles;

            priceOfItem = order.Items.Find(x => x.SKU == _itemSKU).Price;

            countOfItemInOrder = order.Items.FindAll(x => x.SKU == _itemSKU).Count;

            numberOfBundles = countOfItemInOrder / _itemCountInOneBundle;

            if (numberOfBundles == 0)
                return 0;

            amountWithoutDiscount = numberOfBundles * _itemCountInOneBundle * priceOfItem;

            amountWithDiscount = _priceForBundle * numberOfBundles;

            totalDiscount = amountWithoutDiscount - amountWithDiscount;


            return totalDiscount;

        }
    }
}

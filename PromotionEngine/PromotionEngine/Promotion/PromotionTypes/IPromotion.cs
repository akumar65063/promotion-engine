using System;
namespace PromotionEngine.Promotion.PromotionTypes
{
    // Every Promotion type should implement the method in this interface
    // to get the total discount amount after applying promotion.
    public interface IPromotion
    {
        double GetPromotionDiscount();
    }
}

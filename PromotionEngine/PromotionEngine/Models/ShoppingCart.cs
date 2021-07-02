using System;
using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class ShoppingCart
    {
        public List<Item> cartItems;

        public ShoppingCart()
        {
        }

        //Fetch the items from the cart
        public List<Item> GetCartItems()
        {
            return new List<Item>() { new Item { SKU='A'},
                                      //new Item { SKU='A'},
                                      //new Item { SKU='A'},
                                      //new Item { SKU='A'},                                   
                                      //new Item { SKU='A'},
                                      //new Item { SKU='A'},
                                      //new Item { SKU='A'},

                                      new Item { SKU='B'},
                                      //new Item { SKU='B'},
                                      //new Item { SKU='B'},
                                      //new Item { SKU='B'},
                                      //new Item { SKU='B'},

                                      new Item { SKU='C'},
                                      //new Item { SKU='C'},
                                      //new Item { SKU='D'}
                                      };
        }
}

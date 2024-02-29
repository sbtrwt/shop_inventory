using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Shop
{
    public class ShopService
    {
        private ShopController shopController;
       
        public ShopService(ShopModel model)
        {
            shopController = new ShopController(model);
        }
    }
}
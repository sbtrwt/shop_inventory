using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShopInventory.Item;

namespace ShopInventory.Shop
{
    public class ShopService
    {
        private ShopController shopController;
        private ItemContainerService itemContainerService;
        private ItemDescriptionService itemDescriptionService;

        public ShopService(ShopModel model)
        {
            shopController = new ShopController(model);
        }
        public void InjectDependencies(ItemContainerService itemContainerService, ItemDescriptionService itemDescriptionService)
        {
            this.itemContainerService = itemContainerService;
            this.itemDescriptionService = itemDescriptionService;
        }
        public void Start()
        {
            itemContainerService.InitItemContainer();
            itemContainerService.SetParent(shopController.GetViewObject());

            itemDescriptionService.SetParent(shopController.GetViewObject());
        }
    }
}
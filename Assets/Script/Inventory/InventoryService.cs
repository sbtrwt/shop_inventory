using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShopInventory.Item;

namespace ShopInventory.Inventory
{
    public class InventoryService
    {
        private InventoryController inventoryController;
        private ItemContainerService itemContainerService;
        private ItemDescriptionService itemDescriptionService;

        public InventoryService(InventoryModel model)
        {
            inventoryController = new InventoryController(model);
        }
        public void InjectDependencies(ItemContainerService itemContainerService, ItemDescriptionService itemDescriptionService)
        {
            this.itemContainerService = itemContainerService;
            this.itemDescriptionService = itemDescriptionService;
        }
        public void Start()
        {
            itemContainerService.InitItemContainer();
            itemContainerService.SetParent(inventoryController.GetViewObject());

            itemDescriptionService.SetParent(inventoryController.GetViewObject());
        }

    }
}
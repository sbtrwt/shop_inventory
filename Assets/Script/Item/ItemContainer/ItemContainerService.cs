using ShopInventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Item
{
    public class ItemContainerService
    {
        private ItemContainerController itemContainerController;
        private ItemService itemService;
        ItemContainerModel itemContainerModel;
        public ItemContainerService(ItemContainerModel model)
        {
            itemContainerModel = model;
        }
        public void InjectDependencies(ItemService itemService)
        {
            this.itemService = itemService;
            itemContainerController = new ItemContainerController(itemContainerModel);
        }
        public void InitItemContainer()
        {
            itemService.InitController(itemContainerModel.allItems, itemContainerController.GetViewObject());
            itemService.SetAllSelectableItems(itemContainerModel.allSelectableItems);
        }

        public void SetParent(GameObject parent)
        {
            itemContainerController.SetParent(parent);
        }
        
    }
}
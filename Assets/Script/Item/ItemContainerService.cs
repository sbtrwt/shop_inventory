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
               itemContainerController = new ItemContainerController(model);
        }
        public void InjectDependencies(ItemService itemService)
        {
            this.itemService = itemService;
        }
        public void InitItemContainer()
        {
            itemService.InitController(itemContainerModel.allItems, itemContainerController.GetViewObject());
           
        }

        public void SetParent(GameObject parent)
        {
            itemContainerController.SetParent(parent);
        }
        
    }
}
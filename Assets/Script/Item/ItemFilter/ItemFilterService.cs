using ShopInventory.Event;
using ShopInventory.Player;
using ShopInventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemFilterService
    {
        private ItemSO itemData;
        private GameObject parent;
        private EventService eventService;
        private ItemFilterController itemFilterController;
        private ItemFilterModel itemFilterModel;
        public ItemFilterService(ItemFilterModel itemFilterModel) 
        {
            this.itemFilterModel = itemFilterModel;
        }

        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
            itemFilterController = new ItemFilterController(itemFilterModel, eventService);
        }

        public void SetParent(GameObject parent)
        {
            itemFilterController.SetParent(parent);
        }

       
    }
}
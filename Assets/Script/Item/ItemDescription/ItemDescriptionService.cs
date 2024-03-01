using ShopInventory.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemDescriptionService
    {
        private ItemSO itemData;
        private GameObject parent;
        private EventService eventService;
        private ItemDescriptionController itemDescriptionController;
        private ItemDescriptionModel itemDescriptionModel;
        public ItemDescriptionService(ItemDescriptionModel itemDescriptionModel) 
        {
            this.itemDescriptionModel = itemDescriptionModel;
        }

        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
            itemDescriptionController = new ItemDescriptionController(itemDescriptionModel, eventService);
        }

        public void SetParent(GameObject parent)
        {
            itemDescriptionController.SetParent(parent);
        }
    }
}
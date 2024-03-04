using ShopInventory.Event;
using ShopInventory.Player;
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

        public void InjectDependencies(EventService eventService, PlayerService playerService)
        {
            this.eventService = eventService;
            itemDescriptionController = new ItemDescriptionController(itemDescriptionModel, eventService, playerService);
        }

        public void SetParent(GameObject parent)
        {
            itemDescriptionController.SetParent(parent);
        }

        public void SetItemAction(ItemAction itemAction)
        {
            itemDescriptionController.SetItemAction(itemAction);
        }
    }
}
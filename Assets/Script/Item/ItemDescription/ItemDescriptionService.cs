using ShopInventory.Event;
using ShopInventory.Player;
using ShopInventory.UI;
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

        public void InjectDependencies(EventService eventService, PlayerService playerService, UIService uiService,ItemService itemService)
        {
            this.eventService = eventService;
            itemDescriptionController = new ItemDescriptionController(itemDescriptionModel, eventService, playerService, uiService, itemService);
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
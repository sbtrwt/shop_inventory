using ShopInventory.Event;
using ShopInventory.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemDescriptionController
    {
        private ItemSO selectedItem;
        private EventService eventService;
        private ItemDescriptionView itemDescriptionView;
        private ItemDescriptionModel itemDescriptionModel;
        private GameObject parent;
        private ItemAction itemAction;
        private float itemQuantity;
        private PlayerService playerService;
        public ItemDescriptionController(ItemDescriptionModel model, EventService eventService, PlayerService playerService)
        {
            this.playerService = playerService;
            this.eventService = eventService;
            itemDescriptionModel = model;
            InitView();
            this.eventService.OnItemClick.AddListener(SetItemData);
        }
        public void InitView()
        {
            itemDescriptionView = Object.Instantiate(itemDescriptionModel.itemDescriptionSO.ItemDescriptionPrefab);
            itemDescriptionView.SetController(this);
        }
        public void SetParent(GameObject parent)
        {
            this.parent = parent;
            itemDescriptionView.SetParent(parent);
        }
        public GameObject GetViewObject()
        {
            return itemDescriptionView.gameObject;
        }
        public void SetItemData(ItemSO item)
        {
            selectedItem = item;
            selectedItem.actionQuantity = item.quantity;
            itemQuantity = item.quantity;
            itemDescriptionView.SetItemData(item);
        }
        public void SetItemAction(ItemAction itemAction)
        {
            this.itemAction = itemAction;
        }
        public void OnActionButtonClick()
        {
            if (itemQuantity == 0) { return; }

            selectedItem.actionQuantity = itemQuantity;
            ItemSO tempSO = ScriptableObject.CreateInstance<ItemSO>();
            tempSO.Clone(selectedItem);
            tempSO.quantity = itemQuantity;
            int cost = 0;
            switch (itemAction)
            {
                case ItemAction.Buy:
                    //Check gold to buy
                    cost =(int)(itemQuantity * tempSO.buyPrice);
                    if(cost <= playerService.GetGold())
                    {
                        playerService.AddGold(-cost);
                        eventService.OnItemBuy.InvokeEvent(tempSO);
                    }
                    break;
                case ItemAction.Sell:
                    cost = (int)(itemQuantity * tempSO.sellPrice);
                    playerService.AddGold(cost);
                    eventService.OnItemSell.InvokeEvent(tempSO);
                    break;
                default:
                eventService.OnItemSell.InvokeEvent(tempSO) ;
                    break;
            }
        }
        public void OnAddQuantity() 
        { 
            itemQuantity += 1;
            if(selectedItem.quantity < itemQuantity)
            {
                itemQuantity = selectedItem.quantity;
            }
            itemDescriptionView.SetQuantity(itemQuantity);
        }
        public void OnRemoveQuantity()
        {
            itemQuantity -= 1;
            if (itemQuantity < 0) itemQuantity = 0;
            itemDescriptionView.SetQuantity(itemQuantity);
        }

        
    }
}
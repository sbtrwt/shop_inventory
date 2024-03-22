using ShopInventory.Event;
using ShopInventory.Global;
using ShopInventory.Player;
using ShopInventory.UI;
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
        private UIService uIService;
        private ItemService itemService;
        public ItemDescriptionController(ItemDescriptionModel model, EventService eventService, PlayerService playerService, UIService uIService, ItemService itemService)
        {
            this.playerService = playerService;
            this.eventService = eventService;
            itemDescriptionModel = model;
            InitView();
            this.eventService.OnItemClick.AddListener(SetItemData);
            this.uIService = uIService;
            this.itemService = itemService;
        }
        public void InitView()
        {
            itemDescriptionView = Object.Instantiate(itemDescriptionModel.ItemDescriptionSO.ItemDescriptionPrefab);
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
            selectedItem.ActionQuantity = item.Quantity;
            itemQuantity = item.Quantity;
            itemDescriptionView.SetItemData(item);
        }
        public void SetItemAction(ItemAction itemAction)
        {
            this.itemAction = itemAction;
        }
        public void OnActionButtonClick()
        {
            if (itemQuantity == 0) { return; }
            ItemSO tempSO = GetSelectedItemClone();

            uIService.SetMessage("");
            float inventoryWeight = playerService.GetWeight(); ;

            switch (itemAction)
            {
                case ItemAction.Buy:
                    //Check gold to buy
                    ItemBuyAction(tempSO, inventoryWeight);
                    break;
                case ItemAction.Sell:
                    ItemSellAction(tempSO);
                    break;
                default:
                    break;
            }
        }

        private ItemSO GetSelectedItemClone()
        {
            ItemSO tempSO;
            selectedItem.ActionQuantity = itemQuantity;
            tempSO = ScriptableObject.CreateInstance<ItemSO>();
            tempSO.Clone(selectedItem);
            tempSO.Quantity = itemQuantity;
            return tempSO;
        }

        private int ItemSellAction(ItemSO tempSO)
        {
            int cost = (int)(itemQuantity * tempSO.SellPrice);
            playerService.AddGold(cost);
            eventService.OnItemSell.InvokeEvent(tempSO);
            ResetItemData();
            eventService.OnWeightChange.InvokeEvent();
            return cost;
        }

        private void ItemBuyAction(ItemSO tempSO, float inventoryWeight)
        {
            int cost = (int)(itemQuantity * tempSO.BuyPrice);
            float tempWeight = (itemQuantity * tempSO.Weight);
            if (cost <= playerService.GetGold())
            {
                if ((tempWeight + inventoryWeight) <= GlobalConstant.INVENTORY_MAX_WEIGHT)
                {
                    playerService.AddGold(-cost);
                    eventService.OnItemBuy.InvokeEvent(tempSO);
                    ResetItemData();
                    eventService.OnWeightChange.InvokeEvent();
                }
                else
                {
                    uIService.SetMessage(GlobalConstant.TextWeightOverload);
                }
            }
            else
            {
                uIService.SetMessage(GlobalConstant.TextNotEnoughGold);
            }
        }

        public void OnAddQuantity()
        {
            if (selectedItem != null)
            {
                itemQuantity += 1;
                if (selectedItem.Quantity < itemQuantity)
                {
                    itemQuantity = selectedItem.Quantity;
                }
                itemDescriptionView.SetQuantity(itemQuantity);
            }
        }
        public void OnRemoveQuantity()
        {
            itemQuantity -= 1;
            if (itemQuantity < 1) itemQuantity = 1;
            itemDescriptionView.SetQuantity(itemQuantity);
        }

        public void ResetItemData()
        {
            ItemSO tempSO = ScriptableObject.CreateInstance<ItemSO>();
            tempSO.Clone(selectedItem);
            selectedItem = tempSO;
            selectedItem.ID = 0;
            selectedItem.Icon = null;
            selectedItem.Quantity = 0;
            selectedItem.Description = "";
            selectedItem.SellPrice = 0;
            selectedItem.BuyPrice = 0;
            selectedItem.Weight = 0;
            itemQuantity = 0;
            itemDescriptionView.SetItemData(selectedItem);
        }
    }
}
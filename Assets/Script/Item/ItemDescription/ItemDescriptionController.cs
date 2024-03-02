using ShopInventory.Event;
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
        public ItemDescriptionController(ItemDescriptionModel model, EventService eventService)
        {
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
            itemDescriptionView.SetItemData(item);
        }
        public void SetItemAction(ItemAction itemAction)
        {
            this.itemAction = itemAction;
        }
        public void OnActionButtonClick()
        {
            switch (itemAction)
            {
                case ItemAction.Buy:
                    eventService.OnItemBuy.InvokeEvent(selectedItem);
                    break;
                case ItemAction.Sell:
                    eventService.OnItemSell.InvokeEvent(selectedItem);
                    break;
                default:
                eventService.OnItemSell.InvokeEvent(selectedItem) ;
                    break;
            }
        }
    }
}
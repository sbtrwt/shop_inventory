using ShopInventory.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemController
    {
        private ItemView itemView;
        private ItemModel itemModel;
        private EventService eventService;

        public ItemController(ItemModel model, EventService eventService)
        {
            this.eventService = eventService;
            itemModel = model;
            InitView();
            if(model?.parent)
                SetParent(model.parent);
        }

        public void InitView()
        {
            itemView = Object.Instantiate(itemModel.itemSO.itemViewPrefab);
            itemView.SetController(this);
            itemView.SetItemView(itemModel.itemSO);
        }
        public void SetParent(GameObject parent)
        {
            itemModel.parent = parent;
            itemView.SetParent(parent);
        }
        public ItemSO GetItemData()
        {
            return itemModel.itemSO;
        }

        public void OnItemClick(ItemSO itemData)
        {
            eventService.OnItemClick.InvokeEvent(itemData);
        }
        public void DestroyItemView()
        {
            GameObject.Destroy(itemView.gameObject);
        }
        public void SetItemView(ItemSO item)
        {
            itemView.SetItemView(item);
        }
    }
}
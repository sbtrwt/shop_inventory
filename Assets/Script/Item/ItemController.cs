using ShopInventory.Event;
using ShopInventory.Sound;
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
        private SoundService soundService;
        public ItemController(ItemModel model, EventService eventService, SoundService soundService)
        {
            this.eventService = eventService;
            this.soundService = soundService;
            itemModel = model;
            InitView();
            if(model?.Parent)
                SetParent(model.Parent);
        }

        public void InitView()
        {
            itemView = Object.Instantiate(itemModel.ItemSO.ItemViewPrefab);
            itemView.SetController(this);
            itemView.SetItemView(itemModel.ItemSO);
        }
        public void SetParent(GameObject parent)
        {
            itemModel.Parent = parent;
            itemView.SetParent(parent);
        }
        public ItemSO GetItemData()
        {
            return itemModel.ItemSO;
        }
        public void SetItemData(ItemSO item)
        {
             itemModel.ItemSO = item;
        }

        public void OnItemClick(ItemSO itemData)
        {
            soundService.PlaySoundEffects(SoundType.ItemClick);
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
        public void SetVisible(bool isShow)
        {
            itemView.gameObject.SetActive(isShow);
        }
    }
}
using ShopInventory.Event;
using ShopInventory.Player;
using ShopInventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Item
{
    public class ItemFilterController
    {
        private ItemSO selectedItem;
        private EventService eventService;

        private GameObject parent;
        private ItemFilterView itemFilterView;
        private ItemFilterModel itemFilterModel;
        public ItemFilterController(ItemFilterModel itemFilterModel, EventService eventService)
        {
            this.itemFilterModel = itemFilterModel;
            this.eventService = eventService;

            InitView();


        }
        public void InitView()
        {
            itemFilterView = Object.Instantiate(itemFilterModel.itemFilterSO.ItemFilterPrefab);
            itemFilterView.SetController(this);
        }
        public void SetParent(GameObject parent)
        {
            this.parent = parent;
            itemFilterView.SetParent(parent);
        }
        public GameObject GetViewObject()
        {
            return itemFilterView.gameObject;
        }

        public void OnClickFilter(ItemType type)
        {
            Debug.Log(type);
            eventService.OnItemFilter.InvokeEvent(type);
        }

    }
}
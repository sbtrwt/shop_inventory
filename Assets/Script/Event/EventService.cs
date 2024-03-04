using ShopInventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Event
{
    public class EventService
    {


        public EventController<ItemSO> OnItemClick { get; private set; }
        public EventController<ItemSO> OnItemBuy { get; private set; }
        public EventController<ItemSO> OnItemSell { get; private set; }

        public EventController<int> OnGoldChange { get; private set; }
        public EventController OnMining { get; private set; }
        public EventService()
        {
            OnItemBuy = new EventController<ItemSO>();
            OnItemSell = new EventController<ItemSO>();
            OnItemClick = new EventController<ItemSO>();
            OnGoldChange = new EventController<int>();
            OnMining = new EventController();
        }
    }
}
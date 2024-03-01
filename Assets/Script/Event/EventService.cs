using ShopInventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Event
{
    public class EventService
    {


        public EventController<ItemSO> OnItemClick { get; private set; }
        public EventController OnItemBuy { get; private set; }
        public EventController OnItemSell { get; private set; }


        public EventService()
        {
            OnItemBuy = new EventController();
            OnItemSell = new EventController();
            OnItemClick = new EventController<ItemSO>();
        }
    }
}
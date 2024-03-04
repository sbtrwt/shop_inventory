using ShopInventory.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Player
{
    public class PlayerService
    {
        private int gold;
        private EventService eventService;
        public PlayerService()
        {

        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
        }

        public void AddGold(int gold)
        {
            gold += gold;
        }

        public int GetGold()
        {
            return gold;
        }
    }
}
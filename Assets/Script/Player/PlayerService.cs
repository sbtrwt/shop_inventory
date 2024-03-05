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
        private float weight;
        public PlayerService()
        {

        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
        }

        public void AddGold(int gold)
        {
            this.gold += gold;
            eventService.OnGoldChange.InvokeEvent(this.gold);
        }

        public int GetGold()
        {
            return gold;
        }
        public void AddWeight(float val)
        {
            this.weight += val;
        
        }
        public void SetWeight(float val)
        {
            this.weight = val;
         
        }
        public float GetWeight()
        {
            return weight;
        }
    }
}
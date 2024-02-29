using ShopInventory.Inventory;
using ShopInventory.Player;
using ShopInventory.Event;
using ShopInventory.Shop;
using ShopInventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopInventory.Global
{
    public class ServiceLocator 
    {
        private EventService eventService;
        private PlayerService playerService;
        private ShopService shopService;
        private InventoryService inventoryService;
        

        [SerializeField] private UIService uiService;


        public ServiceLocator(ServiceLocatorData data)
        {
            InitializeServices(data);
            InjectDependencies();
        }

        private void InitializeServices(ServiceLocatorData data)
        {
            eventService = new EventService();
            playerService = new PlayerService();
            shopService = new ShopService();
            inventoryService = new InventoryService();
        }

        private void InjectDependencies()
        {
        }
        public void Update()
        {
            
        }
    }

}

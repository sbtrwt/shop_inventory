using ShopInventory.Inventory;
using ShopInventory.Player;
using ShopInventory.Event;
using ShopInventory.Shop;
using ShopInventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShopInventory.Item;

namespace ShopInventory.Global
{
    public class ServiceLocator
    {
        private EventService eventService;
        private PlayerService playerService;
        private ShopService shopService;
        private InventoryService inventoryService;
        private ItemContainerService itemContainerService;
        private ItemService itemService;

        [SerializeField] private UIService uiService;


        public ServiceLocator(ServiceLocatorModel data)
        {
            InitializeServices(data);
            InjectDependencies();
        }

        private void InitializeServices(ServiceLocatorModel data)
        {
            eventService = new EventService();
            playerService = new PlayerService();
            shopService = new ShopService(data.ShopModel);
            inventoryService = new InventoryService();
            itemContainerService = new ItemContainerService(data.ItemContainerModel);
            itemService = new ItemService();
        }

        private void InjectDependencies()
        {
            itemContainerService.InjectDependencies(itemService);
            shopService.InjectDependencies(itemContainerService);
        }
        public void Start()
        {
            shopService.Start();
        }
        public void Update()
        {

        }
    }

}

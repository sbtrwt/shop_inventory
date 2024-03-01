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
        private ItemContainerService itemContainerService;

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
            shopService = new ShopService(new ShopModel
            {
                shopSO = data.ShopSO,
                canvas = data.Canvas,
                shopButton = data.ShopButton
            });
            inventoryService = new InventoryService();
            itemContainerService = new ItemContainerService();
        }

        private void InjectDependencies()
        {
        }
        public void Update()
        {

        }
    }

}

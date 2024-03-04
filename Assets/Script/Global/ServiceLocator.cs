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

        //Shop component services
        private ItemContainerService shopItemContainerService;
        private ItemDescriptionService shopItemDescriptionService;
        private ItemService shopItemService;

        //Inventory component services
        private ItemContainerService inventoryItemContainerService;
        private ItemDescriptionService inventoryItemDescriptionService;
        private ItemService inventoryItemService;

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
            inventoryService = new InventoryService(data.InventoryModel);
            //Shop services
            shopItemContainerService = new ItemContainerService(data.ShopModel.ItemContainerModel);
            shopItemService = new ItemService();
            shopItemDescriptionService = new ItemDescriptionService(data.ShopModel.ItemDescriptionModel);

            //Shop services
            inventoryItemContainerService = new ItemContainerService(data.InventoryModel.ItemContainerModel);
            inventoryItemService = new ItemService();
            inventoryItemDescriptionService = new ItemDescriptionService(data.InventoryModel.ItemDescriptionModel);
        }

        private void InjectDependencies()
        {
            //Shop injection
            shopItemService.InjectDependencies(eventService);
            shopItemContainerService.InjectDependencies(shopItemService);
            shopService.InjectDependencies(shopItemContainerService, shopItemDescriptionService, eventService, shopItemService);
            shopItemDescriptionService.InjectDependencies(eventService);

            //Inventory injection
            inventoryItemService.InjectDependencies(eventService);
            inventoryItemContainerService.InjectDependencies(inventoryItemService);
            inventoryService.InjectDependencies(inventoryItemContainerService, inventoryItemDescriptionService, eventService, inventoryItemService);
            inventoryItemDescriptionService.InjectDependencies(eventService);
        }
        public void Start()
        {
            shopService.Start();
            inventoryService.Start();
        }
        public void Update()
        {

        }
    }

}

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
        private UIService uIService;
        //Shop component services
        private ItemContainerService shopItemContainerService;
        private ItemDescriptionService shopItemDescriptionService;
        private ItemService shopItemService;
        private ItemFilterService shopItemFilterService;

        //Inventory component services
        private ItemContainerService inventoryItemContainerService;
        private ItemDescriptionService inventoryItemDescriptionService;
        private ItemService inventoryItemService;
        private ItemFilterService inventoryItemFilterService;


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
            shopItemFilterService = new ItemFilterService(data.ShopModel.ItemFilterModel);

            //Shop services
            inventoryItemContainerService = new ItemContainerService(data.InventoryModel.ItemContainerModel);
            inventoryItemService = new ItemService();
            inventoryItemDescriptionService = new ItemDescriptionService(data.InventoryModel.ItemDescriptionModel);
            inventoryItemFilterService = new ItemFilterService(data.InventoryModel.ItemFilterModel);

            //UI service
            uiService = new UIService(data.UIModel);
        
        }

        private void InjectDependencies()
        {
            playerService.InjectDependencies(eventService);
            //Shop injection
            shopItemService.InjectDependencies(eventService, uiService);
            shopItemContainerService.InjectDependencies(shopItemService);
            shopItemFilterService.InjectDependencies(eventService);
            shopItemDescriptionService.InjectDependencies(eventService, playerService, uiService);
            shopService.InjectDependencies(shopItemContainerService, shopItemDescriptionService, eventService, shopItemService, shopItemFilterService);

            //Inventory injection
            inventoryItemService.InjectDependencies(eventService, uiService);
            inventoryItemContainerService.InjectDependencies(inventoryItemService);
            inventoryItemDescriptionService.InjectDependencies(eventService, playerService, uiService);
            inventoryItemFilterService.InjectDependencies(eventService);
            inventoryService.InjectDependencies(inventoryItemContainerService, inventoryItemDescriptionService, eventService, inventoryItemService, inventoryItemFilterService);

            //UI service injection
            uiService.InjectDependencies(eventService);
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

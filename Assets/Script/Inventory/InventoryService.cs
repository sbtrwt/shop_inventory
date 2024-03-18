using ShopInventory.Item;
using ShopInventory.Event;
using ShopInventory.Player;

namespace ShopInventory.Inventory
{
    public class InventoryService
    {
        private InventoryController inventoryController;
        private ItemContainerService itemContainerService;
        private ItemDescriptionService itemDescriptionService;
        private EventService eventService;
        private ItemService itemService;
        private InventoryModel inventoryModel;
        private ItemFilterService itemFilterService;
        private PlayerService playerService;
        public InventoryService(InventoryModel model)
        {
            inventoryController = new InventoryController(model);
            this.inventoryModel = model;
        }
       
        public void InjectDependencies(ItemContainerService itemContainerService, ItemDescriptionService itemDescriptionService, EventService eventService, ItemService itemService, ItemFilterService itemFilterService, PlayerService playerService)
        {
            this.itemContainerService = itemContainerService;
            this.itemDescriptionService = itemDescriptionService;
            this.eventService = eventService;
            this.itemService = itemService;
            this.itemFilterService = itemFilterService;
            this.playerService = playerService;
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            this.eventService.OnItemSell.AddListener(this.itemService.OnActionRemove);
            this.eventService.OnItemBuy.AddListener(this.itemService.OnActionAdd);
            this.eventService.OnMining.AddListener(this.itemService.OnMining);
            this.eventService.OnWeightChange.AddListener(SetWeight);
        }

        public void Start()
        {
            itemContainerService.InitItemContainer();
            itemContainerService.SetParent(inventoryController.GetViewObject());

            itemDescriptionService.SetParent(inventoryController.GetViewObject());
            itemDescriptionService.SetItemAction(ItemAction.Sell);

            itemFilterService.SetParent(inventoryController.GetViewObject());
            SetWeight();
        }
        public void SetWeight() 
        {
            float weight = itemService.GetAllWeight();
            playerService.SetWeight(weight);
            inventoryController.SetWeight(weight);
        }

    }
}
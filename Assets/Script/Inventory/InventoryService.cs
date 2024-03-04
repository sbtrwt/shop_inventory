using ShopInventory.Item;
using ShopInventory.Event;

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
        public InventoryService(InventoryModel model)
        {
            inventoryController = new InventoryController(model);
            this.inventoryModel = model;
        }
       
        public void InjectDependencies(ItemContainerService itemContainerService, ItemDescriptionService itemDescriptionService, EventService eventService, ItemService itemService, ItemFilterService itemFilterService)
        {
            this.itemContainerService = itemContainerService;
            this.itemDescriptionService = itemDescriptionService;
            this.eventService = eventService;
            this.itemService = itemService;
            this.eventService.OnItemSell.AddListener(this.itemService.OnActionRemove);
            this.eventService.OnItemBuy.AddListener(this.itemService.OnActionAdd);
            this.eventService.OnMining.AddListener(this.itemService.OnMining);
            this.itemFilterService = itemFilterService;
        }
        public void Start()
        {
            itemContainerService.InitItemContainer();
            itemContainerService.SetParent(inventoryController.GetViewObject());

            itemDescriptionService.SetParent(inventoryController.GetViewObject());
            itemDescriptionService.SetItemAction(ItemAction.Sell);

            itemFilterService.SetParent(inventoryController.GetViewObject());
        }

    }
}
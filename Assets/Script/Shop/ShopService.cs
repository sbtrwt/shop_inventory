using ShopInventory.Item;
using ShopInventory.Event;

namespace ShopInventory.Shop
{
    public class ShopService
    {
        private ShopController shopController;
        private ItemContainerService itemContainerService;
        private ItemDescriptionService itemDescriptionService;
        private EventService eventService;
        private ItemService itemService;
        private ItemFilterService itemFilterService;
        public ShopService(ShopModel model)
        {
            shopController = new ShopController(model);
        }
        public void InjectDependencies(ItemContainerService itemContainerService, ItemDescriptionService itemDescriptionService, EventService eventService, ItemService itemService, ItemFilterService itemFilterService)
        {
            this.itemContainerService = itemContainerService;
            this.itemDescriptionService = itemDescriptionService;
            this.eventService = eventService;
            this.itemService = itemService;
            this.itemFilterService = itemFilterService;
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            this.eventService.OnItemSell.AddListener(this.itemService.OnActionAdd);
            this.eventService.OnItemBuy.AddListener(this.itemService.OnActionRemove);
        }

        public void Start()
        {
            itemContainerService.InitItemContainer();
            itemContainerService.SetParent(shopController.GetViewObject());

            itemDescriptionService.SetParent(shopController.GetViewObject());
            itemDescriptionService.SetItemAction(ItemAction.Buy);

            itemFilterService.SetParent(shopController.GetViewObject());
        }
    }
}
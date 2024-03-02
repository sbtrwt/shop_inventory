using ShopInventory.Inventory;
using ShopInventory.Item;
using ShopInventory.Shop;
using System;


namespace ShopInventory.Global
{
    [Serializable]
    public class ServiceLocatorModel
    {
        public ShopModel ShopModel;
        public ItemContainerModel ItemContainerModel;
        public ItemDescriptionModel ItemDescriptionModel;
        public InventoryModel InventoryModel;
    }
}

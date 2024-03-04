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
        public InventoryModel InventoryModel;
    }
}

using ShopInventory.Inventory;
using ShopInventory.Item;
using ShopInventory.Shop;
using ShopInventory.Sound;
using ShopInventory.UI;
using System;


namespace ShopInventory.Global
{
    [Serializable]
    public class ServiceLocatorModel
    {
        public ShopModel ShopModel;
        public InventoryModel InventoryModel;
        public UIModel UIModel;
        public SoundModel SoundModel;
    }
}

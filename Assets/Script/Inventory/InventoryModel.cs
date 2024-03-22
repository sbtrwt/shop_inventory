using ShopInventory.Item;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Inventory
{
    [Serializable]
    public class InventoryModel
    {
        public InventorySO InventorySO;
        public GameObject Canvas;
        public Button ToggleButton;
        public ItemContainerModel ItemContainerModel;
        public ItemDescriptionModel ItemDescriptionModel;
        public ItemFilterModel ItemFilterModel;
    }
}

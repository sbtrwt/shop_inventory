using ShopInventory.Item;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Inventory
{
    [Serializable]
    public class InventoryModel
    {
        public InventorySO inventorySO;
        public GameObject canvas;
        public Button toggleButton;
        public ItemContainerModel ItemContainerModel;
        public ItemDescriptionModel ItemDescriptionModel;
        public ItemFilterModel ItemFilterModel;
    }
}

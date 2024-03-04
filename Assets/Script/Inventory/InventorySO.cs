using System;
using UnityEngine;

namespace ShopInventory.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
    public class InventorySO : ScriptableObject
    {
        public int ID;
        public InventoryView InventoryPrefab;
    }
}

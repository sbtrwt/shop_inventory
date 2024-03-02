using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Item
{
    public enum ItemType { Material, Weapon, Consumable, Treasure }
    public enum ItemRarity { VeryCommon, Common, Rare, Epic, Legendary }
    public enum ItemAction { Buy, Sell }

    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class ItemSO : ScriptableObject
    {
        public int ID;
        public ItemType type;
        public Sprite icon;
        public string description;
        public float buyPrice;
        public float sellPrice;
        public float weight;
        public ItemRarity rarity;
        public float quantity;
        public ItemView itemViewPrefab;

    }
}
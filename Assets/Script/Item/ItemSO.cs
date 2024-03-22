using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Item
{
    public enum ItemType {None, Material, Weapon, Consumable, Treasure }
    public enum ItemRarity {None, VeryCommon, Common, Rare, Epic, Legendary }
    public enum ItemAction { Buy, Sell }

    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class ItemSO : ScriptableObject
    {
        public int ID;
        public ItemType Type;
        public Sprite Icon;
        public string Description;
        public float BuyPrice;
        public float SellPrice;
        public float Weight;
        public ItemRarity Rarity;
        public float Quantity;
        public ItemView ItemViewPrefab;
        public float ActionQuantity;
        public string ShortName;
        public ItemSO() { }
        public void Clone( ItemSO item)
        {
            ID = item.ID;
            Type = item.Type;
            Icon = item.Icon;
            Description = item.Description;
            BuyPrice = item.BuyPrice;
            SellPrice = item.SellPrice;
            Weight = item.Weight;
            Rarity = item.Rarity;
            Quantity = item.Quantity;
            ItemViewPrefab = item.ItemViewPrefab;
            ActionQuantity = item.ActionQuantity;
            ShortName = item.ShortName;
        }
    }
}
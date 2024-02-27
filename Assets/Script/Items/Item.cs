using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Material, Weapon, Consumable, Treasure}
public enum ItemRarity { VeryCommon, Common, Rare, Epic, Legendary}

[CreateAssetMenu(fileName ="New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public Sprite icon;
    public string description;
    public float buyPrice;
    public float sellPrice;
    public float weight;
    public ItemRarity rarity;
    public float quantity;

}
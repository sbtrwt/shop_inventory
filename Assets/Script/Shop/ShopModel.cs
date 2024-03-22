
using ShopInventory.Item;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Shop
{
    [Serializable]
    public class ShopModel
    {
        public ShopSO ShopSO;
        public GameObject Canvas;
        public Button ShopButton;
        public ItemContainerModel ItemContainerModel;
        public ItemDescriptionModel ItemDescriptionModel;
        public ItemFilterModel ItemFilterModel;
    }
}

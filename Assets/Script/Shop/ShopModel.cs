
using ShopInventory.Item;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Shop
{
    [Serializable]
    public class ShopModel
    {
        public ShopSO shopSO;
        public GameObject canvas;
        public Button shopButton;
        public ItemContainerModel ItemContainerModel;
        public ItemDescriptionModel ItemDescriptionModel;
        public ItemFilterModel ItemFilterModel;
    }
}

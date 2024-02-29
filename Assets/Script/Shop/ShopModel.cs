using ShopInventory.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

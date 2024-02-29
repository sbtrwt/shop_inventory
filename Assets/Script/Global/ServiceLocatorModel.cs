using ShopInventory.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ShopInventory.Global
{
    [Serializable]
    public class ServiceLocatorModel
    {
        public ShopSO ShopSO;
        public GameObject Canvas;
        public Button ShopButton;
    }
}

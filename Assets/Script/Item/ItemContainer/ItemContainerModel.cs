using ShopInventory.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShopInventory.Item
{
    [Serializable]
    public class ItemContainerModel
    {
        public List<ItemSO> AllItems;
        public GameObject Parent;
        public ItemContainerSO ItemContainerSO;
        public List<ItemSO> AllSelectableItems;
    }
}

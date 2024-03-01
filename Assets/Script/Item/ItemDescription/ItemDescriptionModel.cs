using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShopInventory.Item
{
    [Serializable]
    public class ItemDescriptionModel
    {
        public ItemSO itemData;
        public GameObject parent;
        public ItemDescriptionSO itemDescriptionSO;
    }
}

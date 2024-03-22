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
        public ItemSO ItemData;
        public GameObject Parent;
        public ItemDescriptionSO ItemDescriptionSO;
    }
}

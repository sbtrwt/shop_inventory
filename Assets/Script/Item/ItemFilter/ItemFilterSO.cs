using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShopInventory.Item
{
    [CreateAssetMenu(fileName = "New ItemFilter", menuName = "ItemFilter")]

    public class ItemFilterSO : ScriptableObject
    {
        public int ID;
        public ItemFilterView ItemFilterPrefab;
    }
}

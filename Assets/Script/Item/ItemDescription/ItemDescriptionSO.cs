using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShopInventory.Item
{
    [CreateAssetMenu(fileName = "New ItemDescription", menuName = "ItemDescription")]

    public class ItemDescriptionSO : ScriptableObject
    {
        public int ID;
        public ItemDescriptionView ItemDescriptionPrefab;
    }
}

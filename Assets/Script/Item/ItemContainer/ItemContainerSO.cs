using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShopInventory.Item
{
    [CreateAssetMenu(fileName = "New ItemContainer", menuName = "ItemContainer")]
    public class ItemContainerSO : ScriptableObject
    {
        public int ID;
        public ItemContainerView ItemContainerPrefab;
    }
}
